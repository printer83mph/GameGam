using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GuyMovement))]

public class ToggleCameras : MonoBehaviour
{

    public Camera camera1;
    public Camera camera2;

    public IdlePoint switchToCam1;
    public IdlePoint switchToCam2;

    private GuyMovement mover;

    // Start is called before the first frame update
    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;

        mover = GetComponent<GuyMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (mover.location == switchToCam1 && !mover.isMoving())
        {
            camera1.enabled = true;
            camera2.enabled = false;
        } else if (mover.location == switchToCam2 && !mover.isMoving())
        {
            camera1.enabled = false;
            camera2.enabled = true;
        }
    }
}
