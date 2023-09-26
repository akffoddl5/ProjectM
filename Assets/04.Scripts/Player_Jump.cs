using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : PlayerState
{
	public Player_Jump(string animBoolName, StateMachine stateMachine, PlayerControl player) : base(animBoolName, stateMachine, player)
	{
	}

	public override void Enter()
	{
		base.Enter();
		get_Jump = jump_power;
		
		//rb.AddForce(new Vector3(0, jump_power, 0));
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void Update()
	{
		base.Update();

		

		


	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();

		

		if (get_X != 0 || get_Y != 0)
		{
			Quaternion requireRotation = Quaternion.LookRotation(dir);
			player.transform.rotation = requireRotation;
		}

		CC.Move((dir * speed + new Vector3(0, get_Jump, 0)) * Time.deltaTime);
		//get_Jump += Physics.gravity.y * Time.deltaTime;
		if (!player.GroundDetected())
			get_Jump += Physics.gravity.y * Time.deltaTime;

		if (CC.velocity.y <= 0)
		{
			Debug.Log("flag1  " + CC.velocity.y + " " + get_Jump);
			stateMachine.ChangeState(player.airState);
		}
	}
}
