using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    [Range(5, 50)]
    public float weaponDamage = 25f;

    public float range = 500f;
    public float damageFallOff = 1f;


    public void ShootBullet()
    {
        GetComponent<Animator>().SetTrigger("isFiring");
        RaycastHit hit;
        Transform shootingPoint = transform.Find("ShootingPoint");
        if(shootingPoint == null) { Debug.Log("no shooting point"); }
        bool isHit = Physics.Raycast(   shootingPoint.position,
                                        shootingPoint.forward,
                                        out hit,
                                        range);
        if (isHit)
        {
            float distance = Vector3.Distance(hit.transform.position,
                                                shootingPoint.transform.position);
            //if the object hit has a health component, deal damage
            if (hit.collider.GetComponent<Health>() != null)
            {
                hit.collider.GetComponent<Health>().TakeDamage(weaponDamage - distance * damageFallOff);
            }
        }
    }

}
