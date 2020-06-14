using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    [Range(5, 50)]
    public float weaponDamage = 25f;

    public float range = 500f;
    public float damageFallOff = 1f;

    public Camera camera;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            OnClickShoot();
        }

    }
    private void OnClickShoot()
    {
        GetComponent<Animator>().SetTrigger("isFiring");
        RaycastHit hit;
        bool isHit = Physics.Raycast(camera.transform.position,
            camera.transform.forward,
            out hit,
            range);
        if (isHit)
        {
            float distance = Vector3.Distance(hit.transform.position, camera.transform.position);
            if (hit.collider.GetComponent<Health>() != null)
            {
                hit.collider.GetComponent<Health>().TakeDamage(weaponDamage - distance * damageFallOff);
            }
        }
    }

}
