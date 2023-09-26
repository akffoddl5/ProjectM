using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //상태머신
    public StateMachine stateMachine;

    public PlayerState idleState;
    public PlayerState airState;
    public PlayerState jumpState;
    public PlayerState landState;
    public PlayerState dashState;
    public PlayerState runState;

	//체크
	public Transform groundCheck1;
	//public Transform groundCheck2;
	//public Transform groundCheck3;
	//public Transform groundCheck4;

	//컴포넌트
	public CharacterController CC;
    //public Rigidbody rb;
	public Animator anim;
	public CinemachineVirtualCamera vcam;
	public float rotationY;


	//움직임
	public float speed = 5f;
    public float jump_power = 500f;

	


	private void Awake()
	{
		CC = GetComponent<CharacterController>();
		//rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();

		stateMachine = new StateMachine();
		
        idleState = new Player_Idle("IDLE",stateMachine, this);
		airState = new Player_Air("AIR",stateMachine, this);
		jumpState = new Player_Jump("JUMP", stateMachine, this);
		landState = new Player_Land("LAND", stateMachine, this);
		dashState = new Player_Dash("DASH", stateMachine, this);
		runState = new Player_Run("RUN", stateMachine, this);

		stateMachine.Initialize(idleState);
	}

	private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
	{
		if (lfAngle < -360f) lfAngle += 360f;
		if (lfAngle > 360f) lfAngle -= 360f;
		return Mathf.Clamp(lfAngle, lfMin, lfMax);
	}



	void Start()
    {
        stateMachine.cur_state.Enter();

		Cursor.lockState = CursorLockMode.Locked;
	}

    void Update()
    {
		stateMachine.cur_state.Update();

		//화면각 계산
		var state = vcam.State;
		var rotation = state.FinalOrientation;
		var euler = rotation.eulerAngles;
		rotationY = euler.y;
		var roundRotationY = Mathf.RoundToInt(rotationY);


	}

	public Quaternion FlatRotation => Quaternion.Euler(0, rotationY, 0);

	private void FixedUpdate()
	{
		stateMachine.cur_state.FixedUpdate();
	}

	public bool GroundDetected()
	{
		if (Physics.OverlapSphere(groundCheck1.position, 0.5f, LayerMask.GetMask("Ground")) != null &&
			Physics.OverlapSphere(groundCheck1.position, 0.5f, LayerMask.GetMask("Ground")).Length != 0) return true;
		return false;
		
		//return Physics.Raycast(groundCheck1.position, Vector3.down, 0.1f, LayerMask.GetMask("Ground")) ||
		//	Physics.Raycast(groundCheck2.position, Vector3.down, 0.1f, LayerMask.GetMask("Ground")) ||
		//	Physics.Raycast(groundCheck3.position, Vector3.down, 0.1f, LayerMask.GetMask("Ground")) ||
		//	Physics.Raycast(groundCheck4.position, Vector3.down, 0.1f, LayerMask.GetMask("Ground"));
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawSphere(groundCheck1.position, 0.5f);
		//Gizmos.DrawLine(groundCheck1.position, groundCheck1.position + new Vector3(0, -0.1f, 0));
		//Gizmos.DrawLine(groundCheck2.position, groundCheck2.position + new Vector3(0, -0.1f, 0));
		//Gizmos.DrawLine(groundCheck3.position, groundCheck3.position + new Vector3(0, -0.1f, 0));
		//Gizmos.DrawLine(groundCheck4.position, groundCheck4.position + new Vector3(0, -0.1f, 0));
	}
}
