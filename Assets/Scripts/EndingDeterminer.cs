using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingDeterminer : MonoBehaviour
{

    public void GoodEnding()
    {
        SceneManager.LoadScene("GoodEnding");
    }

    public void BadEnding()
    {
        SceneManager.LoadScene("BadEnding");
    }

}
