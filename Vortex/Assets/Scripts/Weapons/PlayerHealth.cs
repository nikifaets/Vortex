using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{

    public UnityEvent died;
    public float maxHealth = 100;
    public float health = 100;
    public PostProcessVolume woundedPPV;

    public void TakeDamage(float damage)
    {

        if (damage > 0)
        {
            health -= damage;
            Debug.Log("took " + damage + " damage.");
        }

        if (health < 35)
        {
                woundedPPV.enabled = true;
        }
        else woundedPPV.enabled = false;


        if(health <= 0){

            died.Invoke();
        }
    }
    public void RestoreHealth(float healthToRestore)
    {
        if (health + healthToRestore >= 100)
        {
            health = 100;
        }
        else { 
            health += healthToRestore; 
        }
    }

}
