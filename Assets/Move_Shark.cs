using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Shark : StateMachineBehaviour
{
	public GameObject player;
	Rigidbody rb;
	public float speed;

	public float att;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		player = GameObject.FindWithTag("Player");
		rb = animator.GetComponent<Rigidbody>();
	}

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		var a = new Vector3(player.transform.position.x, animator.transform.position.y, player.transform.position.z) - animator.transform.position;
		animator.transform.LookAt(player.transform);

		if (Vector3.Distance(new Vector3(player.transform.position.x, animator.transform.position.y, player.transform.position.z), animator.transform.position) > 15f)
		{
			rb.velocity = a.normalized * speed * Time.deltaTime;
			Debug.Log("red3");
		}
		else if (Vector3.Distance(new Vector3(player.transform.position.x, animator.transform.position.y, player.transform.position.z), animator.transform.position) < 5f)
		{
			rb.velocity = -a.normalized * speed * Time.deltaTime;
			Debug.Log("red2");
		}
		else
		{
			Debug.Log("red");
			animator.Play("Attack");
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
