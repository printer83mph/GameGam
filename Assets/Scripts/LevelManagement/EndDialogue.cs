using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDialogue : MonoBehaviour
{

    public GameObject dialogue;
    public IdlePoint[] postConvoTargetLocations;

    public string failScene;

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
        foreach (IdlePoint i in postConvoTargetLocations)
        {
            i.hasNoiseOn = true;
        }
    }

    public void failedConvo()
    {
        SceneManager.LoadScene(failScene);
    }

}
