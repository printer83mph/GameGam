using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Clickable))]

public class Door : MonoBehaviour
{

    public bool locked;

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

}
