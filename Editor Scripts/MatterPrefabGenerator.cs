using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit;
using System.IO;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MatterPrefabGenerator : EditorWindow
{
    private bool useMeshCollider = true;
    private MatterType matterType = MatterType.Matter;

    [MenuItem("Tools/Matter Prefab Generator")]
    public static void ShowWindow()
    {
        GetWindow<MatterPrefabGenerator>("Matter Prefab Generator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Matter Prefab Settings", EditorStyles.boldLabel);
        useMeshCollider = EditorGUILayout.Toggle("Use Mesh Collider", useMeshCollider);
        matterType = (MatterType)EditorGUILayout.EnumPopup("Matter Type", matterType);

        if (GUILayout.Button("Generate Prefabs from Selection"))
        {
            GeneratePrefabs();
        }
    }

    private void GeneratePrefabs()
    {
        GameObject[] selected = Selection.gameObjects;

        if (selected.Length == 0)
        {
            Debug.LogWarning("No objects selected.");
            return;
        }

        string savePath = "Assets/Prefabs/";
        Directory.CreateDirectory(savePath);

        foreach (GameObject model in selected)
        {
            GameObject root = new GameObject(model.name + "_MatterObject");
            root.transform.position = model.transform.position;

            // Visual child
            GameObject visual = Instantiate(model, root.transform);
            visual.name = "Visual";

            // Rigidbody
            Rigidbody rb = root.AddComponent<Rigidbody>();
            rb.useGravity = true;

            // Collider
            Collider col = useMeshCollider
                ? root.AddComponent<MeshCollider>()
                : root.AddComponent<BoxCollider>();

            if (col is MeshCollider mc) mc.convex = true;

            // XR + audio + script
            root.AddComponent<XRGrabInteractable>();
            root.AddComponent<AudioSource>();

            MatterChecker checker = root.AddComponent<MatterChecker>();
            checker.type = matterType;

            // Save
            string prefabPath = savePath + root.name + ".prefab";
            PrefabUtility.SaveAsPrefabAsset(root, prefabPath);

            DestroyImmediate(root);
        }

        Debug.Log("MatterObject prefabs created and saved to Assets/Prefabs.");
    }
}
