using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Air : PlayerState
{
	public Player_Air(string animBoolName, StateMachine stateMachine, PlayerControl player) : base(animBoolName, stateMachine, player)
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

	public override void FixedUpdate()
	{
		//Debug.Log(get_Jump + " in air" + get_Jump);
		base.FixedUpdate();

		if (get_X != 0 || get_Y != 0)
		{
			dir = player.FlatRotation * new Vector3(get_X, 0, get_Y).normalized;
			Quaternion requireRotation = Quaternion.LookRotation(dir);
			player.transform.rotation = requireRotation;
		}

		CC.Move((dir * speed + new Vector3(0, get_Jump, 0)) * Time.deltaTime);

		if (!player.GroundDetected())
			get_Jump += Physics.gravity.y * 3 * Time.deltaTime;

		if (player.GroundDetected())
		{
			stateMachine.ChangeState(player.idleState);
		}
	}

	public override void Update()
	{
		base.Update();

		
	}
}
