using UnityEngine;

public class ElectronOrbit : MonoBehaviour
{
    public float speed = 50f;
    public float radius = 1.2f;
    public float verticalWobble = 0.1f;
    public float radiusWobble = 0.2f;

    private float angleOffset;
    private float timeOffset;
    private Transform electron;

    void Start()
    {
        // Find child (the electron object)
        if (transform.childCount > 0)
            electron = transform.GetChild(0);

        angleOffset = Random.Range(0f, 360f);
        timeOffset = Random.Range(0f, 1000f);
    }

    void Update()
    {
        if (electron == null) return;

        float angle = Time.time * speed + angleOffset;

        // Dynamic radius + wobble
        float dynamicRadius = radius + Mathf.Sin(Time.time * 0.5f + timeOffset) * radiusWobble;

        // Calculate orbit position (rotated around orbit axis)
        Vector3 localPos = Quaternion.Euler(0, angle, 0) * Vector3.forward * dynamicRadius;

        // Add vertical wobble
        localPos.y += Mathf.Sin(Time.time * speed * 0.2f + timeOffset) * verticalWobble;

        // Apply position
        electron.localPosition = localPos;
    }
}
