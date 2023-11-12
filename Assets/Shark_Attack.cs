using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark_Attack : StateMachineBehaviour
{
	public GameObject player;
	Rigidbody rb;
	public float speed;
	public float att;

    public float attack_cool;
    [SerializeField] float attack_cool_max = 5f;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		player = GameObject.FindWithTag("Player");//
		rb = animator.GetComponent<Rigidbody>();
	}

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attack_cool -= Time.deltaTime;
        if (attack_cool < 0)
        {
            Instantiate(ObjectPool.instance.prefab_shark_bullet, animator.GetComponent<Shark>().attack_generator.transform.position, Quaternion.identity);
            attack_cool = attack_cool_max;
        }

		var a = new Vector3(player.transform.position.x, animator.transform.position.y, player.transform.position.z) - animator.transform.position;
		animator.transform.LookAt(player.transform);

		if (Vector3.Distance(new Vector3(player.transform.position.x, animator.transform.position.y, player.transform.position.z), animator.transform.position) > 15f)
		{
			animator.Play("Move");
		}
		else if (Vector3.Distance(new Vector3(player.transform.position.x, animator.transform.position.y, player.transform.position.z), animator.transform.position) < 5f)
		{
			rb.velocity = -a.normalized * speed * Time.deltaTime;
			animator.Play("Move");
		}
		else
		{
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
