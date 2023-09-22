using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Idle : PlayerState
{
	public Player_Idle(string animBoolName, StateMachine stateMachine, PlayerControl player) : base(animBoolName, stateMachine, player)
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
			stateMachine.ChangeState(player.jumpState);
		}
		else if (get_X != 0 || get_Y != 0)
		{
			stateMachine.ChangeState(player.runState);
		}
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
	}
}
