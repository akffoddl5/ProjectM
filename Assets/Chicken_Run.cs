using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_Run : StateMachineBehaviour
{
	public Transform des_pos;
	Rigidbody rb;
	Vector3 move_dir;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		rb = animator.GetComponent<Rigidbody>();
		des_pos = GameObject.Find("AirPlanePos").transform;
		move_dir = animator.transform.position - des_pos.position;
		var a = Quaternion.LookRotation(move_dir);
		animator.transform.rotation = a;
		//Debug.Log(des_pos + " 여기로 부터 도망쳐1 " + move_dir);
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		rb.velocity = move_dir * 0.5f;
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
