using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Run_Game : StateMachineBehaviour
{
	Vector3 move_dir;
	public Transform des_pos1;
	public Transform des_pos2;
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//des_pos = GameObject.Find("AirPlanePos").transform;
		//move_dir = animator.transform.position - des_pos.position;
		//var a = Quaternion.LookRotation(move_dir);
		//animator.transform.rotation = a;
		//Debug.Log(des_pos + " 여기로 부터 도망쳐1 " + move_dir);
		
		//animator.gameObject.GetComponent<Rigidbody>().useGravity = false;
		des_pos1 = GameObject.Find("RunPos1").transform;
		des_pos2 = GameObject.Find("RunPos2").transform;
		
		animator.gameObject.GetComponent<NavMeshAgent>().speed = 10;

	}


	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//animator.GetComponent<CharacterController>().Move(move_dir * 0.5f);
		animator.gameObject.GetComponent<NavMeshAgent>().SetDestination(des_pos1.position); 
		animator.speed = 2.4f;
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
