using UnityEngine;


public enum MatterType
{
    None,
    Matter,
    NnotMatter,
    Solid,
    Liquid,
    Gas,
    Plasma
}

public class MatterObject : MonoBehaviour
{
    public MatterType type;
}
