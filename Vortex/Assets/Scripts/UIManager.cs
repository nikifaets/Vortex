using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject pauseMenu;
    const string KEY_PAUSE = "q";

    // Update is called once per frame
    void Update()
    {
        handleInput();
    }

    void handleInput(){

        if(Input.GetKey(KEY_PAUSE)){

            Debug.Log("Pause");
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
    }
}
