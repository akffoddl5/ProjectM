using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dash : PlayerState
{
	public Player_Dash(string animBoolName, StateMachine stateMachine, PlayerControl player) : base(animBoolName, stateMachine, player)
	{
	}

	public override void Enter()
	{
		base.Enter();
		Debug.Log("dash!!!");
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
	}
}
