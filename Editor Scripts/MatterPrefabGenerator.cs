using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit;
using System.IO;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class MatterPrefabGenerator : MonoBehaviour
{
    [MenuItem("Tools/Generate Matter Prefabs")]
    static void WrapSelectedAsMatterPrefabs()
    {
        foreach (GameObject selected in Selection.gameObjects)
        {
            if (selected == null) continue;

            // Create root prefab object
            GameObject root = new GameObject(selected.name + "_MatterObject");
            root.transform.position = selected.transform.position;

            // Create Visual child
            GameObject visual = Instantiate(selected, root.transform);
            visual.name = "Visual";

            // Add required components
            Rigidbody rb = root.AddComponent<Rigidbody>();
            rb.useGravity = true;

            Collider col = root.AddComponent<BoxCollider>(); // You can switch to MeshCollider if needed

            XRGrabInteractable grab = root.AddComponent<XRGrabInteractable>();
            root.AddComponent<AudioSource>();

            MatterChecker checker = root.AddComponent<MatterChecker>();
            checker.type = MatterType.Matter; // Default; change per prefab

            // Save as prefab
            string prefabPath = "Assets/Prefabs/" + root.name + ".prefab";
            Directory.CreateDirectory("Assets/Prefabs");

            PrefabUtility.SaveAsPrefabAsset(root, prefabPath);

            // Clean up the temporary root from scene
            DestroyImmediate(root);
        }

        Debug.Log("Finished generating MatterObject prefabs.");
    }
}
