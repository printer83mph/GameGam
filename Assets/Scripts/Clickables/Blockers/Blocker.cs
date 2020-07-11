using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour
{

    public bool allowMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void switchMode()
    {
        allowMovement = !allowMovement;
        Debug.Log(allowMovement ? "Allowing Movement" : "Denying Movement");
    }



}
