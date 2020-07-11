using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Clickable))]

public class LightSwitch : MonoBehaviour
{

    public Transform[] transforms;

    public bool isLit;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Clickable>().onClickDelegate += OnClick;
    }

    void OnClick()
    {
        isLit = !isLit;
        foreach (Transform i in transforms)
        {
            i.GetComponent<IdlePoint>().isLit = isLit;
        }
        Debug.Log(isLit ? "lightswitch is on" : "lightswitch is off");
    }
}
