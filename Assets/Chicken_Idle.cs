using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_Idle : StateMachineBehaviour
{
	Rigidbody rb;

	Dictionary<int, string> anim_dic;
    bool _start = true;
    float b = -1f;
 

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		b = Random.Range(-0.5f, 0.7f);
		if (_start)
        {
			
			rb = animator.GetComponent<Rigidbody>();
			anim_dic = new Dictionary<int, string>();
			anim_dic.Add(5, "WalkInPlace0");
			anim_dic.Add(1, "Idle");
			anim_dic.Add(2, "RunInPlace0");
			anim_dic.Add(3, "Eat");
			anim_dic.Add(4, "TurnHead");
            int a = Random.Range(1, 5);
            animator.Play(anim_dic[a]);

            _start = false;
		}
		

        
	}

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        

		animator.transform.Rotate(new Vector3(0, b, 0));
        //animator.transform.Rotate(new Vector3(0, 2f, 0));
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
