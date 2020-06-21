using UnityEngine;

public class Shoot : MonoBehaviour
{
    WeaponStats weaponStats;

    void Start()
    {
        weaponStats = GetComponent<WeaponStats>();
    }

    public void ShootBullet()
    {
        GetComponent<Animator>().SetTrigger("isFiring");
        RaycastHit hit;
        Transform shootingPoint = transform.Find("ShootingPoint");
        if(shootingPoint == null) { Debug.Log("no shooting point"); }
        bool isHit = Physics.Raycast(   shootingPoint.position,
                                        shootingPoint.forward,
                                        out hit,
                                        weaponStats.range);
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
        }
    }

}
