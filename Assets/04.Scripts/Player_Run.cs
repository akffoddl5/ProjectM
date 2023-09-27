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
		if (get_Space)
		{
			Debug.Log("jump ");
			stateMachine.ChangeState(player.jumpState);
		}
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		

		if (get_X != 0 || get_Y != 0)
		{
			Quaternion requireRotation = Quaternion.LookRotation(dir);
			player.transform.rotation = requireRotation;

			CC.Move((dir * speed + new Vector3(0, CC.velocity.y, 0)) * Time.deltaTime);
		}
		else
		{
			//rb.velocity = Vector3.zero;
			stateMachine.ChangeState(player.idleState);
		}
	}
}
