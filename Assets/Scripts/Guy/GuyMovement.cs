using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuyMovement : MonoBehaviour
{

    public Animator guyAnimator;

    public IdlePoint location;

    public IdlePoint levelExit;

    public string nextScene;

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
        if (!inMotion && location == levelExit)
        {
            SceneManager.LoadScene(nextScene);
        }

        //Debug.Log(inMotion ? "moving" : "not moving");
        if (location.isLit && !inMotion)
        {
            location.hasNoiseOn = false; //if we are arriving at a noisy place, turn the noise off
            guyAnimator.SetBool("annoyingNoise", false);
            IdlePoint nextLoc;
            guyAnimator.SetBool("inDarkness", false);
            for (int i = 0; i < location.connectedPoints.GetLength(0); i++)
            {
                nextLoc = location.connectedPoints[i];
                if (nextLoc.isLit && nextLoc.hasNoiseOn)
                {
                    guyAnimator.SetBool("annoyingNoise", true);
                    if (location.allowConnectedPoints[i].allowMovement)
                    {
                        location = nextLoc;
                        inMotion = true;
                        return;
                    }
                }
            }
        } else if (inMotion)
        {
            transform.position = Vector3.MoveTowards(transform.position, location.transform.position, speed * Time.deltaTime);
            if (transform.position == location.transform.position) inMotion = false; //if we reached the destinatoin
        } else
        {
            guyAnimator.SetBool("inDarkness", true);
            IdlePoint nextLoc;
            for (int i = 0; i < location.connectedPoints.GetLength(0); i++)
            {
                nextLoc = location.connectedPoints[i];
                if (nextLoc.isLit && location.allowConnectedPoints[i].allowMovement)
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
