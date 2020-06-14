using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;

    void Update()
    {

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("took damage ");
        Debug.Log(damage);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
