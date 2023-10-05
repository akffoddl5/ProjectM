using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Aim : PlayerState
{


	
	public Player_Aim(string animBoolName, StateMachine stateMachine, PlayerControl player) : base(animBoolName, stateMachine, player)
	{
	}

	public override void Enter()
	{
		base.Enter();

		
		
		player.vcam.gameObject.SetActive(false);
		player.aimCam.gameObject.SetActive(true);
		player.image_Aim.SetActive(true);

		player.aimCam_POV.m_HorizontalAxis.Value = player.vcam_POV.m_HorizontalAxis.Value;
		player.aimCam_POV.m_VerticalAxis.Value = player.vcam_POV.m_VerticalAxis.Value;

	}

	public override void Exit()
	{
		base.Exit();
		player.vcam_POV.m_HorizontalAxis.Value = player.aimCam_POV.m_HorizontalAxis.Value;
		player.vcam_POV.m_VerticalAxis.Value = player.aimCam_POV.m_VerticalAxis.Value;
		player.vcam.gameObject.SetActive(true);
		player.aimCam.gameObject.SetActive(false);
		player.image_Aim.SetActive(false);
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
	}

	public override void Update()
	{
		base.Update();
		if (aiming_out)
		{
			stateMachine.ChangeState(player.idleState);

		}else if(shooting)
		{
			player.Shoot();
			
		}

		//ȭ�鰢 ���
		
		var state = player.aimCam.State;
		var rotation = state.FinalOrientation;
		var euler = rotation.eulerAngles;
		float rotationY = euler.y;
		var roundRotationY = Mathf.RoundToInt(rotationY);

		//Quaternion requireRotation = Quaternion.LookRotation(dir);
		//player.transform.rotation = requireRotation;
		player.transform.rotation = player.FlatRotation;
		player.transform.rotation = Quaternion.Euler(0, roundRotationY, 0);
	}
}
