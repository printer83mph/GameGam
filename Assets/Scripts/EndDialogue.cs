using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDialogue : MonoBehaviour
{

    public GameObject dialogue;

    public IdlePoint[] postConvoTargetLocations;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endConvo()
    {
        dialogue.SetActive(false);
    }

}
