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
        //Debug.Log(inMotion ? "moving" : "not moving");
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
            Transform nextLoc;
            for (int i = 0; i < locScript.connectedPoints.GetLength(0); i++)
            {
                nextLoc = locScript.connectedPoints[i];
                if (nextLoc.GetComponent<IdlePoint>().isLit && locScript.allowConnectedPoints[i].GetComponent<Blocker>().allowMovement)
                {
                    location = nextLoc;
                    inMotion = true;
                    return;
                }
            }
            /*
            foreach(Transform i in locScript.connectedPoints){
                if (i.GetComponent<IdlePoint>().isLit) location = i;
                inMotion = true;
                return;
            }*/
        }
    }
}
