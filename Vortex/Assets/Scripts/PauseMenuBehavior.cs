using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseMenuBehavior : MonoBehaviour
{
    public UnityEvent unpaused;
    public UnityEvent quit;

    public void Resume(){

        Debug.Log("Invoke resume");
        unpaused.Invoke();
    }

    public void Quit(){

        quit.Invoke();
    }
}
