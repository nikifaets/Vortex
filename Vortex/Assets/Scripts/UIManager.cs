using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject aimUI;
    public Camera playerCamera;
    public GameObject healthBars;

    const string KEY_PAUSE = "q";

    void Update()
    {
        HandleInput();
        CreateEnemiesLifeBars();
    }

    void HandleInput(){

        if(Input.GetKey(KEY_PAUSE)){

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

        pauseMenu.SetActive(false);
        aimUI.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void CreateEnemiesLifeBars(){

        healthBars.GetComponent<HealthBarControl>().Clear();

        Transform NPCs = transform.Find("NPCs");

        for(int i=0; i<NPCs.childCount; i++){

            
           Transform enemy = NPCs.GetChild(i);
           if(! IsObjectVisible(enemy.gameObject)) continue;

           healthBars.GetComponent<HealthBarControl>().CreateBar(enemy.gameObject, playerCamera);

            
        }

    }

    bool IsObjectVisible(GameObject obj){

        Renderer renderer = obj.GetComponent<MeshRenderer>();
        return renderer.isVisible;
    }
}
