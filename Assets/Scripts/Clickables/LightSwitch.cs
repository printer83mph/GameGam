using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Clickable))]

public class LightSwitch : MonoBehaviour
{

    public IdlePoint[] idlePoints;
    public Light lightObject;

    public bool isLit;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Clickable>().onClickDelegate += OnClick;
    }

    void OnClick()
    {
        isLit = !isLit;
        lightObject.enabled = isLit;
        foreach (IdlePoint i in idlePoints)
        {
            i.isLit = isLit;
        }
        Debug.Log(isLit ? "lightswitch is on" : "lightswitch is off");
    }
}
