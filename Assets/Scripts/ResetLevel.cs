﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{

    public string levelName;

    public void resetLevel()
    {
        SceneManager.LoadScene(levelName);
    }

}
