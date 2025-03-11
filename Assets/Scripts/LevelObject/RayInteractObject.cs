using UnityEngine;

public enum UseAbleTable
{
    None,
    Health,
    Speed,
    wall,
    End
}

[CreateAssetMenu (fileName = "RayInteractObject", menuName = "Custom/Object", order = 1)]
public class RayInteractObject : ScriptableObject
{
    public bool useAble;
    public UseAbleTable useAbleTable;
    public string objName;
    public string objDescription;
    public float value;
}
