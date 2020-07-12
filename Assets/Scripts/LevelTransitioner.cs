using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitioner : MonoBehaviour
{

    public Animator animator;

    private string nextLevel;

    public void FadeToLevel(string levelName)
    {
        animator.SetTrigger("FadeOut");
        nextLevel = levelName;
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
