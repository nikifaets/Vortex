using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{   

    [Range(0f, 1f)]
    public float hitChance = 1f;

    public Vector3 pivot;
    public GameObject target;
    public NavMeshAgent agent;
    public float minDistToPlayer = 10f;
    private const float TIMER = 2f;
    private float timeElapsed = 0;

    private void Awake()
    {

        pivot = new Vector3(transform.position.x, 0, transform.position.z);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = Mathf.Clamp(timeElapsed - Time.deltaTime, 0, TIMER);
        //Debug.Log(timeElapsed);

    }



    public void Follow()
    {
        Vector3 dir = transform.position - target.transform.position;

        Vector3 targetPos = target.transform.position + minDistToPlayer * Vector3.Normalize(dir);
        agent.SetDestination(targetPos);
    }

    public void Shoot()
    {
        if(timeElapsed <= 0){

            timeElapsed = TIMER;
            
            float willHit = Random.Range(0f, 1f);
            if(willHit <= hitChance){

            }

            else{

            }
        }

    }

    public void GoToPivot(){

        agent.ResetPath();
        agent.SetDestination(pivot);
    }
}
