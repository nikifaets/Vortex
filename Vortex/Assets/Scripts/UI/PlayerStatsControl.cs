using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsControl : MonoBehaviour
{
    
    public GameObject healthBar;

    public GameObject weapon;
    public GameObject ammoBar;

    public GameObject player;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        float health = player.GetComponent<PlayerHealth>().health;
        float maxHealth = player.GetComponent<PlayerHealth>().maxHealth;

        Image foreground = healthBar.transform.Find("Foreground").GetComponent<Image>();
        foreground.fillAmount = health / maxHealth;

        float ammo = weapon.GetComponent<WeaponStats>().ammo;
        float magazine = weapon.GetComponent<WeaponStats>().magazineCapacity;

        Image ammoForeground = ammoBar.transform.Find("Foreground").GetComponent<Image>();
        ammoForeground.fillAmount = ammo / magazine;
    }
}
