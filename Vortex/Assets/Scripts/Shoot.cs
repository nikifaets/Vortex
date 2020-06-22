using UnityEngine;
using UnityEngine.Events;

public class Shoot : MonoBehaviour
{
    WeaponStats weaponStats;
    public UnityEvent onMark;
    public UnityEvent lostAim;
    RaycastHit hit;
    bool isHit = false;
    bool isTargetHit = false;
    bool wasTargetHit = false;
    Transform shootingPoint;

    void Start()
    {
        weaponStats = GetComponent<WeaponStats>();
        shootingPoint = transform.Find("ShootingPoint");
    }

    void Update(){

        //GetComponent<Animator>().SetTrigger("isFiring");
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
