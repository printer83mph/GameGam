using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Clickable))]

public class Door : MonoBehaviour
{

    public bool locked;
    public bool opened;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Clickable>().onClickDelegate += OnClick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        locked = !locked;
        Debug.Log(locked ? "Now Locked" : "Now Unlocked");
    }

    void OpenDoor()//okay to be called if locked
    {
        if (!locked)
        {
            if(!opened)//i.e. if it isn't already opened
            {
                transform.Translate(new Vector3(0, 1, 0));//TODO: door animation?
            }
            opened = true;
        }
    }

    void CloseDoor()
    {
        if (opened)
        {
            transform.Translate(new Vector3(0, -1, 0));
        }
        opened = false;
    }

}
