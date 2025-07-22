using UnityEngine;
using System.Collections.Generic;

public class AtomBuilder : MonoBehaviour
{
    [Header("Particle Prefabs")]
    public GameObject protonPrefab;
    public GameObject neutronPrefab;
    public GameObject electronPrefab;

    [Header("Counts")]
    [Range(1, 20)] public int protonCount = 1;
    [Range(0, 20)] public int neutronCount = 0;
    [Range(1, 10)] public int electronCount = 1;

    private List<GameObject> spawned = new List<GameObject>();

    void OnValidate()
    {
        ClearAtom();
        BuildNucleus();
        BuildElectronShell();
    }

    void BuildNucleus()
    {
        for (int i = 0; i < protonCount; i++)
            SpawnInSphere(protonPrefab, 0.2f);

        for (int i = 0; i < neutronCount; i++)
            SpawnInSphere(neutronPrefab, 0.2f);
    }

    void BuildElectronShell()
    {
        float orbitRadius = 1.2f;

        for (int i = 0; i < electronCount; i++)
        {
            // Generate a random plane to orbit on
            Vector3 axis = Random.onUnitSphere.normalized;
            Vector3 orbitStartPos = Vector3.forward * orbitRadius;

            // Create orbit parent with random rotation
            GameObject orbitParent = new GameObject("ElectronOrbit_" + i);
            orbitParent.transform.parent = transform;
            orbitParent.transform.localPosition = Vector3.zero;
            orbitParent.transform.rotation = Quaternion.LookRotation(axis);

            // Create electron at orbit start position
            GameObject electron = Instantiate(electronPrefab, orbitParent.transform.position + orbitParent.transform.rotation * orbitStartPos, Quaternion.identity);
            electron.transform.parent = orbitParent.transform;

            // Animate orbit
            ElectronOrbit orbitScript = orbitParent.AddComponent<ElectronOrbit>();
            orbitScript.speed = 50f + i * 5f;

            // Track for cleanup
            spawned.Add(orbitParent);
            spawned.Add(electron);
        }
    }



    void SpawnInSphere(GameObject prefab, float range)
    {
        Vector3 randomPos = Random.insideUnitSphere * range;
        GameObject obj = Instantiate(prefab, transform.position + randomPos, Quaternion.identity, transform);
        spawned.Add(obj);
    }

    void ClearAtom()
    {
        // Destroy all previously spawned objects
        for (int i = 0; i < spawned.Count; i++)
        {
            if (spawned[i] != null)
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                    DestroyImmediate(spawned[i]);
                else
                    Destroy(spawned[i]);
#else
            Destroy(spawned[i]);
#endif
            }
        }

        spawned.Clear();
    }

}
