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
		
		timer1 = 7.5f * Time.fixedDeltaTime;
		dash_dir = player.transform.forward;
		//Debug.Log("dash!!!");
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
			//Debug.Log(dash_power + " << ");
			//rb.velocity = dash_dir.normalized * 60f;
			CC.Move(dash_dir.normalized * dash_power * Time.deltaTime);

		}
	}
}
