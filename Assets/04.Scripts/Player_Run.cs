using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Run : PlayerState
{

	public Player_Run(string animBoolName, StateMachine stateMachine, PlayerControl player) : base(animBoolName, stateMachine, player)
	{
	}

	public override void Enter()
	{
		base.Enter();
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
			Vector3 dir = player.FlatRotation * new Vector3(get_X, 0, get_Y).normalized;
			Quaternion requireRotation = Quaternion.LookRotation(dir);
			player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, requireRotation, 600 * Time.deltaTime);
			rb.velocity = dir * speed + new Vector3(0, rb.velocity.y, 0);
		}
		else
		{
			rb.velocity = Vector3.zero;
			stateMachine.ChangeState(player.idleState);
		}
	}
}
