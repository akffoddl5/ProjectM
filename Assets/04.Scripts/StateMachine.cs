using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
	public PlayerState cur_state;

	public void Initialize(PlayerState state)
	{
		cur_state = state;
		cur_state.Enter();
	}

	public void ChangeState(PlayerState state)
	{
		cur_state.Exit();
		cur_state = state;
		cur_state.Enter();
	}


}
