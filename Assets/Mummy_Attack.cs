using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mummy_Attack : StateMachineBehaviour
{
	NavMeshAgent agent;
	
	Transform player;
	public GameObject attack_generator;
	public GameObject red_line;
	GameObject detect_line;
	public GameObject tornado;

	public float timer1;	//timer1 만큼 쫓다가
	public float timer2;    //timer2 만큼 깜빡 거리고 쏘기

	public Vector3 bullet_dir;
	


	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		
		agent = animator.GetComponent<NavMeshAgent>();
		agent.speed = 0f;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		animator.GetComponent<Mummy>().attack_done = false;
		attack_generator = animator.gameObject.GetComponent<Mummy>().attack_generator;
		

		timer1 = 4.0f;
		timer2 = 0.35f;

		animator.SetBool("Move", false);
		animator.SetBool("Attack", true);																																								
	}
	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		timer1 -= Time.deltaTime;


		// 플레이어가 있는 경우에만 실행
		Vector3 playerPosition = player.position;
		Vector3 directionToPlayer = playerPosition - animator.transform.position;
		directionToPlayer.y = 0f; // 수직 방향의 회전을 제한

		if (directionToPlayer != Vector3.zero)
		{
			Quaternion newRotation = Quaternion.LookRotation(directionToPlayer);
			animator.transform.rotation = newRotation;
		}
		//Debug.Log(player.transform.position);
		//var euler = requireRotation.eulerAngles;
		//float rotationY = euler.y;
		//animator.gameObject.transform.rotation = requireRotation;

		//Quaternion requireRotation = Quaternion.LookRotation(dir);
		//player.transform.rotation = requireRotation;


		//레이저 추격 내 손으로부터 플레이어까지 라인 긋기
		if (timer1 > 0)
		{
			if (detect_line == null)
				detect_line = Instantiate(red_line, attack_generator.transform.position, Quaternion.identity);
			detect_line.GetComponent<LineRenderer>().SetPosition(0, attack_generator.transform.position);
			detect_line.GetComponent<LineRenderer>().SetPosition(1, player.transform.position + new Vector3(0,0.7f,0));
			
		}
		else if(timer2 > 0)
		{
			bullet_dir = player.transform.position - attack_generator.transform.position;
			bullet_dir = bullet_dir.normalized;
			animator.GetComponent<Mummy>().Cor_Blink(timer2,detect_line);
			timer2 = -1;
		}

		if (animator.GetComponent<Mummy>().attack_done)
		{
			animator.GetComponent<Mummy>().attack_done = false;
			animator.GetComponent<Mummy>().Shoot(bullet_dir);
			Destroy(detect_line);
			
			animator.SetBool("Move", true);
			animator.SetBool("Attack", false);


		}



	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.GetComponent<Mummy>().attack_done = false;
		Destroy(detect_line);
		//Debug.Log("MUMMY EXIT!!!!");
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
