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
		//Debug.Log("idle");
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
			return;
		}
		else if (get_X != 0 || get_Y != 0)
		{
			
			stateMachine.ChangeState(player.runState);
			return;
		}
		else if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			//´ë½¬
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
