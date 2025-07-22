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
        float radius = 1.2f;

        for (int i = 0; i < electronCount; i++)
        {
            float angle = i * Mathf.PI * 2f / electronCount;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;

            GameObject orbitCenter = new GameObject("ElectronOrbit" + i);
            orbitCenter.transform.parent = transform;
            orbitCenter.transform.localPosition = Vector3.zero;

            GameObject electron = Instantiate(electronPrefab, transform.position + pos, Quaternion.identity);
            electron.transform.parent = orbitCenter.transform;

            orbitCenter.AddComponent<ElectronOrbit>().speed = 50f + i * 10f;

            spawned.Add(electron);
            spawned.Add(orbitCenter);
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
        foreach (var obj in spawned)
        {
#if UNITY_EDITOR
            DestroyImmediate(obj);
#else
            Destroy(obj);
#endif
        }
        spawned.Clear();
    }
}
