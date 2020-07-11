using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GuyMovement))]

public class OnLocationEventTrigger : MonoBehaviour
{

    public IdlePoint onArrivalAt;
    public IdlePoint eventAt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GuyMovement mover = GetComponent<GuyMovement>();
        if (!mover.isMoving() && mover.location == onArrivalAt)
        {
            eventAt.hasNoiseOn = true;
        }
    }
}
