using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Health : MonoBehaviour
{   

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
        if (health < 25)
        {
            woundedPPV.enabled = true;
        }
        else woundedPPV.enabled = false;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public float getHealth()
    {
        return health;
    }
}
