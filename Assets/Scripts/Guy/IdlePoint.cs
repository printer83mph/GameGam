using UnityEngine;

public class IdlePoint : MonoBehaviour
{

    public IdlePoint[] connectedPoints;
    public Blocker[] allowConnectedPoints;

    public bool hasNoiseOn;

    private int _lightsOnMe;

    public void Setup()
    {
        _lightsOnMe = 0;
    }

    public void SetLit(bool lit)
    {
        if (lit)
        {
            addLight();
        } else
        {
            removeLight();
        }

        if (_lightsOnMe < 0) _lightsOnMe = 0; //quick fix to a bug where some lights were being initialized to -1 at start of scene

        Debug.Log(_lightsOnMe);
    }

    public bool isLit()
    {
        return (_lightsOnMe > 0);
    }

    public void addLight()
    {
        _lightsOnMe++;
    }

    public void removeLight()
    {
        _lightsOnMe--;
    }

}
