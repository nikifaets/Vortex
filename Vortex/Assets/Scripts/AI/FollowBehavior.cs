﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class FollowBehavior : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject target = animator.GetComponent<EnemyBehavior>().target;

        Vector3 targetPosition = new Vector3( target.transform.position.x, 
                                        animator.transform.position.y, 
                                        target.transform.position.z ) ;
        animator.transform.LookAt( targetPosition ) ;

       Vector3 targetPos = animator.gameObject.GetComponent<EnemyBehavior>().target.transform.position;

        float dist = Vector3.Distance(targetPos, animator.gameObject.transform.position);

       if(animator.gameObject.GetComponent<SphereCollider>().bounds.Contains(targetPos))
       {
               
               animator.gameObject.GetComponent<EnemyBehavior>().Shoot();
       }

       else{

           animator.gameObject.GetComponent<EnemyBehavior>().Follow();
       }

        RaycastHit hit;
        Vector3 dir = targetPosition - animator.gameObject.transform.position;

        if (Physics.Raycast(animator.gameObject.transform.position, dir, out hit, Mathf.Infinity))
        {
            if(hit.collider != target){

                animator.gameObject.GetComponent<EnemyBehavior>().Follow();
                
            }
        }
       
       Vector3 pivot = animator.gameObject.GetComponent<EnemyBehavior>().pivot;
       if(! animator.gameObject.GetComponent<SphereCollider>().bounds.Contains(pivot)){

           animator.SetTrigger("returnToPivot");
       }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
