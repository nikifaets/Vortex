﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour
{
    public void StartGame(){

        SceneManager.LoadScene("Level01");

    }

    public void QuitGame(){

        Application.Quit();
    }
}
