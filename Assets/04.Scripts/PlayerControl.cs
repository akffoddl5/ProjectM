using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //���¸ӽ�
    public StateMachine stateMachine;
    public PlayerState idleState;
    public PlayerState airState;
    public PlayerState jumpState;
    public PlayerState landState;
    public PlayerState dashState;
    public PlayerState runState;
	public PlayerState aimState;

	//üũ
	public Transform groundCheck1;
	public GameObject image_Aim;
	public Transform leftBulletGenerator;
	public Transform rightBulletGenerator;
	//public Transform groundCheck2;
	//public Transform groundCheck3;
	//public Transform groundCheck4;

	//������Ʈ
	public CharacterController CC;
    //public Rigidbody rb;
	public Animator anim;
	public CinemachineVirtualCamera vcam;
	public CinemachineVirtualCamera aimCam;
	public CinemachineTransposer vcam_trans;
	public CinemachineTransposer aimcam_trans;
	public CinemachinePOV vcam_POV;
	public CinemachinePOV aimCam_POV;

	public float rotationY;


	//������
	public float speed = 5f;
    public float jump_power = 500f;
	public float dash_power = 60f;


	//prefab
	public GameObject prefab_bullet;




	private void Awake()
	{
		
		CC = GetComponent<CharacterController>();
		//vcam_trans = vcam.AddCinemachineComponent<CinemachineTransposer>();
		//aimcam_trans = aimCam.AddCinemachineComponent<CinemachineTransposer>();
		
		vcam_POV = vcam.GetCinemachineComponent<CinemachinePOV>();
		aimCam_POV = aimCam.GetCinemachineComponent<CinemachinePOV>();


		//rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		image_Aim = GameObject.Find("Image_Aim");
		image_Aim.SetActive(false);
		stateMachine = new StateMachine();
		
        idleState = new Player_Idle("IDLE",stateMachine, this);
		airState = new Player_Air("AIR",stateMachine, this);
		jumpState = new Player_Jump("JUMP", stateMachine, this);
		landState = new Player_Land("LAND", stateMachine, this);
		dashState = new Player_Dash("DASH", stateMachine, this);
		runState = new Player_Run("RUN", stateMachine, this);
		aimState = new Player_Aim("Aiming", stateMachine, this);

		stateMachine.Initialize(idleState);
	}

	private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
	{
		if (lfAngle < -360f) lfAngle += 360f;
		if (lfAngle > 360f) lfAngle -= 360f;
		return Mathf.Clamp(lfAngle, lfMin, lfMax);
	}

	public void Shoot()
	{
		var a = Instantiate(prefab_bullet, leftBulletGenerator.position, Quaternion.identity);

		//a.GetComponent<Player_Bullet>().move_dir = AimDetected() - leftBulletGenerator.position;
		a.GetComponent<Player_Bullet>().move_dir = AimDetected();


	}



	void Start()
    {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
        stateMachine.cur_state.Enter();
	}

    void Update()
    {
		stateMachine.cur_state.Update();

		//ȭ�鰢 ���
		var state = vcam.State;
		var rotation = state.FinalOrientation;
		var euler = rotation.eulerAngles;
		rotationY = euler.y;
		var roundRotationY = Mathf.RoundToInt(rotationY);


		//Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.blue, 30f);

	}

	public Quaternion FlatRotation => Quaternion.Euler(0, rotationY, 0);

	int a1 = 0;
	int a2 = 0;
	private void FixedUpdate()
	{
		stateMachine.cur_state.FixedUpdate();
	}

	public bool GroundDetected()
	{
		if (Physics.OverlapSphere(groundCheck1.position, 0.5f, LayerMask.GetMask("Ground")) != null &&
			Physics.OverlapSphere(groundCheck1.position, 0.5f, LayerMask.GetMask("Ground")).Length != 0) return true;
		return false;
		
	}

	public Vector3 AimDetected()
	{
		//return Camera.main.ScreenPointToRay(Input.mousePosition).direction;
		//Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

		Vector3 screenCenter = new Vector3(0.5f, 0.5f, 0f);
		Ray ray = Camera.main.ViewportPointToRay(screenCenter);
		// ȭ�� �߾��� ���� ��ġ�� �����մϴ�.
		RaycastHit hit;

		// ���̸� �߻��ϰ� ��ü�� �ε����� ��ü�� ��ġ�� �����ɴϴ�.
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			Vector3 objectPosition = hit.point;
			//Debug.Log("�߾ӿ� �ִ� ��ü�� ��ġ: " + objectPosition + " " + hit.collider.gameObject.name);
			return objectPosition;
		}

		
		return Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane));



	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawSphere(groundCheck1.position, 0.5f);

		Gizmos.DrawLine(leftBulletGenerator.position, AimDetected()); 
		
		
		//ray = new Ray(firePos.position, dir);
	}
}
