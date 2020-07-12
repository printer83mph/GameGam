using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ToggleableLight : MonoBehaviour
{

    [Tooltip("Set the light's desired intensity in the light component, this boolean will set it on or off on init.")]
    public bool lit;
    public IdlePoint[] idlePoints;

    public Light lightScript;

    private float _initialIntensity;

    private void Start()
    {
        _initialIntensity = lightScript.intensity;
        SetLit(lit);
    }

    private void Update()
    {
        if (lit) SetLit(lit);
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
