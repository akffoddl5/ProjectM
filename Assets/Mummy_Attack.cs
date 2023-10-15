using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mummy_Attack : StateMachineBehaviour
{
	NavMeshAgent agent;
	Transform player;
	public GameObject red_line;
	GameObject detect_line;

	public float timer1;	//timer1 만큼 쫓다가
	public float timer2;	//timer2 만큼 깜빡 거리고 쏘기
	


	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		agent = animator.GetComponent<NavMeshAgent>();
		agent.speed = 0f;
		player = GameObject.FindGameObjectWithTag("Player").transform;

		timer1 = 3f;
		timer2 = 2f;

		animator.SetBool("Move", false);
		animator.SetBool("Attack", true);
	}
	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		timer1 -= Time.deltaTime;
		

		//레이저 추격 내 손으로부터 플레이어까지 라인 긋기
		if (timer1 > 0)
		{
			if (detect_line == null)
				detect_line = Instantiate(red_line, animator.transform.position, Quaternion.identity);
			detect_line.GetComponent<LineRenderer>().SetPosition(0, animator.transform.position);
			detect_line.GetComponent<LineRenderer>().SetPosition(1, player.transform.position);
		}
		else if(timer2 > 0)
		{
			animator.GetComponent<Mummy>().Cor_Blink(timer2,detect_line);
			timer2 = -1;
			
			
		}

		if (animator.GetComponent<Mummy>().attack_done)
		{
			animator.SetBool("Move", true);
			animator.SetBool("Attack", false);
		}



	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.GetComponent<Mummy>().attack_done = false;
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
