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
		rb.AddForce(new Vector3(0, jump_power, 0));
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void Update()
	{
		base.Update();
		Debug.Log("jump");
		if (rb.velocity.y <= 0)
		{
			stateMachine.ChangeState(player.airState);
		}
		

	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
	}
}
