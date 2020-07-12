using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Clickable))]


public class NoiseMaker : MonoBehaviour
{

    public IdlePoint pointOfNoise;

    private bool _used;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Clickable>().onClickDelegate += OnClick;
    }

    void OnClick()
    {
        if (_used) return;
        pointOfNoise.hasNoiseOn = true;
        _used = true;
        Debug.Log("Setting Noise On");
    }
}
