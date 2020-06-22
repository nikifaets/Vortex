using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;
    [SerializeField]
    private float armor = 100f;

    public void TakeDamage(float damage)
    {
        float armorAtStart = armor;
        if (armorAtStart > 0)
        {
            armor -= damage;
            damage -= armorAtStart;
        }
        if (damage > 0)
        {
            health -= damage;
            Debug.Log("took " + damage + " damage.");
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
