using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_Run : StateMachineBehaviour
{

	NavMeshAgent agent;
	Transform player;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		agent = animator.GetComponent<NavMeshAgent>();
		agent.speed = 2.5f;
		player = GameObject.FindGameObjectWithTag("Player").transform;

		animator.SetBool("Run", true);
	}


	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		agent.SetDestination(player.position);

		float distance = Vector3.Distance(player.position, animator.transform.position);

		if (distance > 15f)
		{
			animator.SetBool("Walk", true);
			animator.SetBool("Run", false);
		}
		else if (distance < 1.5f)
		{
			animator.SetBool("Run", false);
			animator.SetBool("Attack", true);
		}
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
