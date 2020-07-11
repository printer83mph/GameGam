using UnityEngine;

public class IdlePoint : MonoBehaviour
{

    public bool isLit;
    public IdlePoint[] connectedPoints;
    public Blocker[] allowConnectedPoints;

    public bool hasNoiseOn;

    public void SetLit(bool lit)
    {
        isLit = lit;
    }

}
