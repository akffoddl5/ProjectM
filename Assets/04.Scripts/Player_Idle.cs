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



		if (!player.GroundDetected())
		{
			stateMachine.ChangeState(player.airState);
		}
		else if (aiming)
		{
			//Debug.Log("aim");
			stateMachine.ChangeState(player.aimState);
		}
		else if (get_Space)
		{
			stateMachine.ChangeState(player.jumpState);
		}
		else if (get_X != 0 || get_Y != 0)
		{
			stateMachine.ChangeState(player.runState);
		}
		else if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			if (dash_cool < 0)
			{
				dash_cool = dash_cool_max;
				stateMachine.ChangeState(player.dashState);

			}
		}
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
	}
}
