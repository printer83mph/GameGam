using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Blocker))]

public class TrafficLightCrosswalk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void changeLight()
    {
        GetComponent<Blocker>().switchMode();
    }

}
