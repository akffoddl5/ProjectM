using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_Walk : StateMachineBehaviour
{
    Rigidbody rb;

    Dictionary<int, string> anim_dic;
    

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		rb = animator.GetComponent<Rigidbody>();
		anim_dic = new Dictionary<int, string>();
        anim_dic.Add(5, "Walk In Place 0");
        anim_dic.Add(1, "Idle");
        anim_dic.Add(2, "Run In Place 0");
        anim_dic.Add(3, "Eat");
        anim_dic.Add(4, "Turn Head");

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        rb.velocity = animator.transform.forward * 1f;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
