using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableLight : MonoBehaviour
{

    public bool lit;
    public IdlePoint[] idlePoints;

    public Light lightScript;

    private float _initialIntensity;

    private void Start()
    {
        _initialIntensity = lightScript.intensity;
        SetLit(lit);
    }

    public void ToggleLit()
    {
        SetLit(!lit);
        Debug.Log("Now " + lit.ToString());
    }

    public void SetLit(bool isLit)
    {
        lit = isLit;
        foreach (IdlePoint i in idlePoints)
        {
            i.SetLit(lit);
        }
        lightScript.intensity = lit ? _initialIntensity : 0;
    }

}
