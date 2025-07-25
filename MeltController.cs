using UnityEngine;

public class MeltController : MonoBehaviour
{
    public Material meltMaterial;
    public float meltSpeed = 0.2f;
    private float dissolve = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // simulate heating
        {
            dissolve += Time.deltaTime * meltSpeed;
            meltMaterial.SetFloat("_DissolveAmount", dissolve);
        }
    }
}
