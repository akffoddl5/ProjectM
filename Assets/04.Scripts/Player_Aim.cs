using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Aim : PlayerState
{
	int roundRotationY;
	


	public Player_Aim(string animBoolName, StateMachine stateMachine, PlayerControl player) : base(animBoolName, stateMachine, player)
	{
	}

	public override void Enter()
	{
		base.Enter();
		
		//Camera.main.cullingMask -= LayerMask.GetMask("Player");
		Camera.main.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));

		player.vcam.gameObject.SetActive(false);
		player.aimCam.gameObject.SetActive(true);
		player.image_Aim.SetActive(true);

		player.aimCam_POV.m_HorizontalAxis.Value = player.vcam_POV.m_HorizontalAxis.Value;
		player.aimCam_POV.m_VerticalAxis.Value = player.vcam_POV.m_VerticalAxis.Value;

	}

	public override void Exit()
	{
		base.Exit();
		Camera.main.cullingMask |= (1 << LayerMask.NameToLayer("Player"));
		player.body.transform.localRotation = Quaternion.identity;
		//Debug.Log(player.body.transform.localRotation.eulerAngles + " :: 66 " + player.body.transform.rotation.eulerAngles);
		//Debug.Log("rotation77 ");

		player.vcam_POV.m_HorizontalAxis.Value = player.aimCam_POV.m_HorizontalAxis.Value;
		player.vcam_POV.m_VerticalAxis.Value = player.aimCam_POV.m_VerticalAxis.Value;
		player.vcam.gameObject.SetActive(true);
		player.aimCam.gameObject.SetActive(false);
		player.image_Aim.SetActive(false);

		
		
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
		if (get_X != 0 || get_Y != 0)
		{
			Debug.Log(dir_aim + " in aim");
			Quaternion requireRotation = Quaternion.LookRotation(dir_aim);
			player.transform.rotation = requireRotation;

			CC.Move((dir_aim * speed * 0.7f + new Vector3(0, CC.velocity.y, 0)) * Time.deltaTime);
		}
	}

	public override void Update()
	{
		base.Update();
		if (aiming_out)
		{
			stateMachine.ChangeState(player.idleState);
			return;

		}else if(shooting)
		{
			player.Shoot();
			
		}

		//화면각 계산
		
		var state = player.aimCam.State;
		var rotation = state.FinalOrientation;
		var euler = rotation.eulerAngles;
		float rotationY = euler.y;
		roundRotationY = Mathf.RoundToInt(rotationY);

		//Quaternion requireRotation = Quaternion.LookRotation(dir);
		//player.transform.rotation = requireRotation;

		//Quaternion requireRotation = Quaternion.LookRotation(dir);
		//player.transform.rotation = requireRotation;
		player.transform.rotation = Quaternion.Euler(0, rotationY, 0);
		player.body.transform.localRotation = Quaternion.Euler(rotation.eulerAngles.x, 0, 0);
		//Debug.Log(rotation.eulerAngles.x);

		//player.spine
	}
}
