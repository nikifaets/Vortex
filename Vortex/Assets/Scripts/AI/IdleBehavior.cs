﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {       
        
        Vector3 targetPos = animator.gameObject.GetComponent<EnemyBehavior>().target.transform.position;

        if(animator.gameObject.GetComponent<SphereCollider>().bounds.Contains(targetPos)){

            animator.SetTrigger("isInRange");
            
        }
       
    }




}
