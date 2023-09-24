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
	public Rigidbody rb;
	public float speed;
	public float jump_power;
	public Animator anim;
	public bool canAnim = false;

	//타이머
	public float timer1;
	public float dash_init_cool_timer;
	public float dash_init_cool = 3f * Time.deltaTime;
	public float dash_cool = 0;
	public float dash_cool_max = 13f * Time.deltaTime;


	//인풋
	public float get_X;
	public float get_Y;
	public bool get_Space;
	public float last_keycode;
	public char last_XY;

	public PlayerState(string animBoolName, StateMachine stateMachine, PlayerControl player)
	{
		this.animBoolName = animBoolName;
		this.stateMachine = stateMachine;
		this.player = player;
		this.rb = player.rb;
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

	}

	public virtual void Update()
	{
		get_X = Input.GetAxisRaw("Horizontal");
		get_Y = Input.GetAxisRaw("Vertical");
		get_Space = Input.GetKeyDown(KeyCode.Space);

		timer1 -= Time.deltaTime;
		dash_cool -= Time.deltaTime;

	}

	public virtual void Exit()
    {
		anim.SetBool(animBoolName, false);
		canAnim = true;
		anim.SetBool("canAnim", canAnim);
	}

	

}
