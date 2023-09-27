using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerState
{
	//상태머신
    public string animBoolName;
    public StateMachine stateMachine;
    public PlayerControl player;
	public CharacterController CC;
	//public Rigidbody rb;
	public float speed;
	public float jump_power;
	public Animator anim;
	public bool canAnim = false;
	public static Vector3 dir;

	//타이머
	public float dash_init_cool_timer;
	public float dash_init_cool = 5f * Time.deltaTime;

	//인풋
	public float get_X;
	public float get_Y;
	public static float get_Jump;
	public bool get_Space;
	public float last_keycode;
	public char last_XY;

	public PlayerState(string animBoolName, StateMachine stateMachine, PlayerControl player)
	{
		this.animBoolName = animBoolName;
		this.stateMachine = stateMachine;
		this.player = player;
		this.CC = player.CC;
		speed = player.speed;
		jump_power = player.jump_power;
		anim = player.anim;
	}

	public virtual void Enter()
    {
		anim.SetBool(animBoolName, true);
		canAnim = false;
		anim.SetBool("canAnim", canAnim);
	}

	public virtual void FixedUpdate()
	{
		//Debug.Log("flag3  " + CC.velocity.y + " " + get_Jump);
		
	}

	public virtual void Update()
	{
		get_X = Input.GetAxisRaw("Horizontal");
		get_Y = Input.GetAxisRaw("Vertical");
		get_Space = Input.GetKeyDown(KeyCode.Space);
		dir = player.FlatRotation * new Vector3(get_X, 0, get_Y).normalized;



		//Vector3 dir = new Vector3(get_X, get_Jump, get_Y);
		//CC.Move(dir * Time.deltaTime);
		//Debug.Log(dir + " " + Physics.gravity.y);
		//get_Jump += Physics.gravity.y * Time.deltaTime;

		//if (dash_init_cool_timer < 0)
		//{
		//	last_keycode = 0;
		//	last_XY = 'O';
		//}


		//if (get_Y != 0)
		//{
		//	Debug.Log("flag1" + last_keycode + last_XY);
		//	if (last_keycode == get_Y && last_XY == 'Y')
		//	{
		//		//대쉬
		//		stateMachine.ChangeState(player.dashState);
		//	}
		//	last_XY = 'Y';
		//	last_keycode = get_Y;
		//}

		//if (get_X != 0)
		//{
		//	if (last_keycode == get_X && last_XY == 'X')
		//	{
		//		//대쉬
		//		stateMachine.ChangeState(player.dashState);
		//	}
		//	last_XY = 'X';
		//	last_keycode = get_X;
		//}





		//dash_init_cool_timer -= Time.deltaTime;

	}

	public virtual void Exit()
    {
		anim.SetBool(animBoolName, false);
		canAnim = true;
		anim.SetBool("canAnim", canAnim);
	}

	

}
