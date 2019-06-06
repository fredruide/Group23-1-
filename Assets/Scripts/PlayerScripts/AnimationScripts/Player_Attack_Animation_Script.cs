﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack_Animation_Script : StateMachineBehaviour
{


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    if (stateInfo.IsName("Player_Attack") || stateInfo.IsName("Player_Attack_2") || stateInfo.IsName("Player_Attack_3"))
    //    {
    //        Debug.Log("NormelizeTime: " + stateInfo.normalizedTime);
    //        Debug.Log("Lenght: " + stateInfo.length);
    //        
    //    }
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Player_Attack") || stateInfo.IsName("Player_Attack_2") || stateInfo.IsName("Player_Attack_3"))
        {
            animator.SetInteger("isAttacking1-3", 0);   
        }
    }

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
