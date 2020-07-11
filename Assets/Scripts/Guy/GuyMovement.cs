using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMovement : MonoBehaviour
{

    public Animator guyAnimator;

    public Transform location;

    public float speed;

    private bool inMotion;

    // Start is called before the first frame update
    void Start()
    {
        inMotion = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inMotion ? "moving" : "not moving");
        IdlePoint locScript = location.GetComponent<IdlePoint>();
        if (locScript.isLit && !inMotion)
        {
            guyAnimator.SetBool("inDarkness", false);
            return;
        } else if (inMotion)
        {
            transform.position = Vector3.MoveTowards(transform.position, location.position, speed * Time.deltaTime);
            if (transform.position == location.position) inMotion = false; //if we reached the destinatoin
        } else
        {
            guyAnimator.SetBool("inDarkness", true);
            if (locScript.topPriority.GetComponent<IdlePoint>().isLit)
            {
                location = locScript.topPriority;
                inMotion = true;
            } else if (locScript.secondPriority.GetComponent<IdlePoint>().isLit)
            {
                location = locScript.secondPriority;
                inMotion = true;
            } else if (locScript.lastPriority.GetComponent<IdlePoint>().isLit)
            {
                location = locScript.lastPriority;
                inMotion = true;
            }
        }
    }
}
