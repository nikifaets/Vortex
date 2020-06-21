using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    const string KEY_PAUSE = "q";

    // Update is called once per frame
    void Update()
    {
        handleInput();
    }

    void handleInput(){

        if(Input.GetKey(KEY_PAUSE)){

            Debug.Log("Pause");
        }
    }
}
