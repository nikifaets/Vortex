﻿using UnityEngine;
using UnityEngine.Events;

public class ShootingBehaviour : MonoBehaviour
{
    WeaponStats weaponStats;
    public UnityEvent onMark;
    public UnityEvent lostAim;
    public Transform shootingPoint;
    public GameObject impactEffect;
    public ParticleSystem muzzleFlash;
    RaycastHit hit;
    bool isHit = false;
    bool isTargetHit = false;
    bool wasTargetHit = false;
    private float nextTimeToFire = 0f;
    private float reloadTimer = 0f; //if >0, weapon is reloading and can't shoot

    void Start()
    {
        weaponStats = GetComponent<WeaponStats>();
    }

    void Update(){

        if (reloadTimer > 0) reloadTimer -= Time.deltaTime;
        if(shootingPoint == null) { Debug.Log("no shooting point"); }

        isHit = Physics.Raycast(   shootingPoint.position,
                                        shootingPoint.forward,
                                        out hit,
                                        weaponStats.range
                                        );



        isTargetHit = false;

        if(isHit){

            if(hit.collider.gameObject.tag == "Enemy"){

                isTargetHit = true;
                onMark.Invoke();

            }
        }

        if(!isTargetHit && wasTargetHit){
            
            lostAim.Invoke();
        }

        wasTargetHit = isTargetHit;
    }

    public void ShootBullet()
    {
        WeaponStats weaponStats = GetComponent<WeaponStats>();
        if (weaponStats.ammo > 0 && Time.time >= nextTimeToFire && reloadTimer <= 0)
        {
            nextTimeToFire = Time.time + 1f / weaponStats.fireRate;
            muzzleFlash.Play();
            weaponStats.ammo--;
            if (isHit)
            {

                float distance = Vector3.Distance(hit.transform.position,
                                                    shootingPoint.transform.position);
                //if the object hit has a health component, deal damage
                if (hit.collider.GetComponent<Health>() != null)
                {
                    float damageToTake = weaponStats.damage - distance * weaponStats.damageFallOff;
                    if (damageToTake < 0) damageToTake = 0;
                    hit.collider.GetComponent<Health>().TakeDamage(damageToTake);
                }
                
                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1f);
            }
            if (weaponStats.ammo <= 0)
            {
                Reload();
            }
        }
    
    }
    public void Reload()
    {
        //reload
        Debug.Log("Reloading...");
        reloadTimer = 2f;
        if (weaponStats.reserveAmmo > 0)
        {
                if (weaponStats.reserveAmmo < weaponStats.magazineCapacity)
                {
                    weaponStats.ammo = weaponStats.reserveAmmo;
                    weaponStats.reserveAmmo = 0;
                }
                else
                {
                    int ammoLeftBeforeReload = weaponStats.ammo;
                    weaponStats.ammo = weaponStats.magazineCapacity;
                    weaponStats.reserveAmmo -= weaponStats.magazineCapacity;
                    weaponStats.reserveAmmo += ammoLeftBeforeReload;
                }
        }
        else
        {
            Debug.Log("Out of ammo.");
        }
        
    }
    public void CreatePortal(GameObject portal)
    {
        if (isHit)
        {
            portal.transform.position = hit.point;

            Quaternion hitObjectRotation = Quaternion.LookRotation(hit.normal);
            portal.transform.rotation = hitObjectRotation;
        }
    }

}
