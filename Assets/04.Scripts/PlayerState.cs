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
	public float dash_power;
	public Animator anim;
	public bool canAnim = false;
	public static Vector3 dir;

	//타이머
	public float timer1;
	public float dash_init_cool_timer;
	public float dash_init_cool = 5f * Time.deltaTime;
	public float dash_cool = 0;
	public float dash_cool_max = 13f * Time.deltaTime;

	//인풋
	public float get_X;
	public float get_Y;
	public static float get_Jump;
	public bool get_Space;
	public float last_keycode;
	public char last_XY;
	public static bool aiming;
	public static bool aiming_out;
	public static bool shooting;

	public PlayerState(string animBoolName, StateMachine stateMachine, PlayerControl player)
	{
		this.animBoolName = animBoolName;
		this.stateMachine = stateMachine;
		this.player = player;
		this.CC = player.CC;
		speed = player.speed;
		jump_power = player.jump_power;
		dash_power = player.dash_power;
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
		//Debug.Log(get_X + " " + get_Y);
		get_Space = Input.GetKeyDown(KeyCode.Space);
		aiming = Input.GetMouseButtonDown(1);
		shooting = Input.GetMouseButton(0);
		if (!aiming)
			aiming_out = Input.GetMouseButtonUp(1);
		else
		{
			aiming_out = false;
		}
		dir = player.FlatRotation * new Vector3(get_X, 0, get_Y).normalized;

		dash_cool -= Time.deltaTime;
		timer1 -= Time.deltaTime;


	}

	public virtual void Exit()
    {
		anim.SetBool(animBoolName, false);
		canAnim = true;
		anim.SetBool("canAnim", canAnim);
	}

	

}
