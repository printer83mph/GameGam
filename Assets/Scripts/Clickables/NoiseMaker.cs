using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Clickable))]


public class NoiseMaker : MonoBehaviour
{

    public IdlePoint pointOfNoise;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Clickable>().onClickDelegate += OnClick;
    }

    void OnClick()
    {
        pointOfNoise.hasNoiseOn = true;
        Debug.Log("Setting Noise On");
    }
}
