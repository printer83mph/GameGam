using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Clickable))]

public class LightSwitch : MonoBehaviour
{

    public ToggleableLight[] lights;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Clickable>().onClickDelegate += OnClick;
    }

    void OnClick()
    {
        foreach (ToggleableLight l in lights)
        {
            l.ToggleLit();
        }
    }
}
