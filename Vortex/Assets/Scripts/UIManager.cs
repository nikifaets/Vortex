using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject aimUI;
    const string KEY_PAUSE = "q";

    void Update()
    {
        handleInput();
    }

    void handleInput(){

        if(Input.GetKey(KEY_PAUSE)){

            Debug.Log("Pause");
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            aimUI.SetActive(false);
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void BackToMenu(){

        SceneManager.LoadScene("MainMenu");
        
    }

    public void Resume(){

        Debug.Log("Resuming");
        pauseMenu.SetActive(false);
        aimUI.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
