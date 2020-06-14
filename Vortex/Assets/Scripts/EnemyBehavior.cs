using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{   
    public Vector3 pivot;
    public GameObject target;
    public NavMeshAgent agent;
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

    // private void OnTriggerEnter(Collider other) 
    // {
        
    //     if(other.tag == "Player"){

    //         //GetComponent<Animator>().SetTrigger("isInRange");

    //     }

    // }

    public void Follow()
    {

        agent.SetDestination(target.transform.position);
    }

    public void Shoot()
    {
        if(timeElapsed <= 0){

            timeElapsed = TIMER;
        }

    }

    public void GoToPivot(){

        agent.ResetPath();
        agent.SetDestination(pivot);
    }
}
