using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dash : PlayerState
{

	Vector3 dash_dir;


	public Player_Dash(string animBoolName, StateMachine stateMachine, PlayerControl player) : base(animBoolName, stateMachine, player)
	{
	}

	

	public override void Enter()
	{
		base.Enter();
		dash_dir = player.transform.forward;
		timer1 = 30 * Time.deltaTime;
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
		if (timer1 < 0)
		{
			stateMachine.ChangeState(player.idleState);
		}
		else
		{
			rb.velocity = dash_dir.normalized * 60f;

		}
	}
}
