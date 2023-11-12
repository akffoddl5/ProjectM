using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : PlayerState
{
	public Player_Die(string animBoolName, StateMachine stateMachine, PlayerControl player) : base(animBoolName, stateMachine, player)
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
		base.FixedUpdate();
	}

	public override void Update()
	{
		base.Update();
		
		
	}
}
