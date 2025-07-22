using UnityEngine;


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

public class MatterObject : MonoBehaviour
{
    public MatterTypeEnum type;
}
