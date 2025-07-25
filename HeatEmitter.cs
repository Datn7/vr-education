using UnityEngine;

public class HeatEmitter : MonoBehaviour
{
    public float heatRate = 1f;

    private void OnTriggerStay(Collider other)
    {
        var heatable = other.GetComponent<HeatableObject>();
        if (heatable)
        {
            heatable.ApplyHeat(heatRate * Time.deltaTime);
        }
    }
}
