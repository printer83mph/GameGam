﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GuyMovement))]

public class OnLocationEventTrigger : MonoBehaviour
{

    public IdlePoint onArrivalAt;
    public IdlePoint eventAt;

    private GuyMovement mover;

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<GuyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mover.isMoving() && mover.location == onArrivalAt)
        {
            eventAt.hasNoiseOn = true;
        }
    }
}
