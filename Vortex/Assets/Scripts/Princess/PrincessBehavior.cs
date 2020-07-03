using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PrincessBehavior : MonoBehaviour
{
    public UnityEvent playerEntered;

    private void OnTriggerEnter(Collider collider){

        if(collider.tag == "Player"){

            playerEntered.Invoke();
        }
    }
}
