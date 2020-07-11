using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GuyMovement))]

public class DialogueOnArrival : MonoBehaviour
{

    public GameObject dialogue;
    public IdlePoint arivalPoint;

    private GuyMovement mover;

    private bool spawned;

    // Start is called before the first frame update
    void Start()
    {
        dialogue.SetActive(false);
        mover = GetComponent<GuyMovement>();
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned) return;
        if (!mover.isMoving() && mover.location == arivalPoint)
        {
            dialogue.SetActive(true);
            spawned = true;
        }
    }
}
