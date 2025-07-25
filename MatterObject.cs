using UnityEngine;
using UnityEngine.Rendering;


public enum MatterTypeEnum
{
    None,
    Matter,
    NnotMatter,
    Solid,
    Liquid,
    Gas,
    Plasma
}
public enum MatterState { Solid, Liquid, Gas }

public class MatterObject : MonoBehaviour
{
    public MatterTypeEnum type;
    public string displayName;
    public GameObject particleView;
    public MatterState state;

    public void ShowParticles(bool show)
    {
        if (particleView != null)
            particleView.SetActive(show);
    }
}
