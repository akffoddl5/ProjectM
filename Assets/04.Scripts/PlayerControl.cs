using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
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
	public PlayerState aimState;

	//체크
	public Transform groundCheck1;
	public GameObject image_Aim;
	public Transform leftBulletGenerator;
	public Transform rightBulletGenerator;
	//public Transform groundCheck2;
	//public Transform groundCheck3;
	//public Transform groundCheck4;

	//컴포넌트
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


	//움직임
	public float speed = 5f;
    public float jump_power = 500f;
	public float dash_power = 60f;

	//타이머
	public float shoot_cool_left;
	public float shoot_cool_right;
	public float shoot_cool_total;
	public bool shoot_left = true;
	public float shoot_cool_max = 0.3f;

	//Rig
	public GameObject body;
	


	private void Awake()
	{
		
		Debug.Log("AWAKE");
		CC = GetComponent<CharacterController>();
		//vcam_trans = vcam.AddCinemachineComponent<CinemachineTransposer>();
		//aimcam_trans = aimCam.AddCinemachineComponent<CinemachineTransposer>();
		
		vcam_POV = vcam.GetCinemachineComponent<CinemachinePOV>();
		aimCam_POV = aimCam.GetCinemachineComponent<CinemachinePOV>();


		//rb = GetComponent<Rigidbody>();
		
		anim = GetComponentInChildren<Animator>();
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

	public IEnumerator IShoot_Shake()
	{
		aimCam_POV.m_VerticalAxis.Value -= 0.5f;
		
		//GameObject.Find("Flare Gun_L").GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0));

		//Debug.Log("cor shake2" + body.transform.rotation.eulerAngles);

		//body.transform.Rotate(-30f, 0, 0);

		//Debug.Log("cor shake2" + body.transform.rotation.eulerAngles);
		//var a = aimCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		//a.m_PivotOffset = new Vector3(0, 50, 0);
		//a.m_FrequencyGain = 0.1f;

		//yield return new WaitForSeconds(0.4f);
		yield return null;

		//a = aimCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		//a.m_PivotOffset = new Vector3(0, 10, 0);
		//a.m_FrequencyGain = 0.01f;

	}

	public void Shoot()
	{
		if (shoot_cool_total < 0)
		{
			if (shoot_left)
			{
				//Quaternion q = Quaternion.Euler(AimDetected() - leftBulletGenerator.position + new Vector3(90, 0, 0));
				Quaternion q = Quaternion.Euler(AimDetected() - leftBulletGenerator.position);
				var a = Instantiate(ObjectPool.instance.prefab_bullet, leftBulletGenerator.position, leftBulletGenerator.rotation);
				shoot_cool_left = shoot_cool_max;
				a.GetComponent<Player_Bullet>().move_dir = AimDetected();
			}
			else
			{
				//Quaternion q = Quaternion.Euler(AimDetected() - rightBulletGenerator.position + new Vector3(90, 0, 0));
				Quaternion q = Quaternion.Euler(AimDetected() - rightBulletGenerator.position);
				var a = Instantiate(ObjectPool.instance.prefab_bullet, rightBulletGenerator.position, leftBulletGenerator.rotation);
				shoot_cool_right = shoot_cool_max;
				a.GetComponent<Player_Bullet>().move_dir = AimDetected();
			}

			shoot_cool_total = shoot_cool_max;
			shoot_left = !shoot_left;
			StartCoroutine(IShoot_Shake());
		}

		//if (shoot_cool_left < 0)
		//{
		//	Quaternion q = Quaternion.Euler(AimDetected() - leftBulletGenerator.position + new Vector3(90,0,0));
			
		//	var a = Instantiate(ObjectPool.instance.prefab_bullet, leftBulletGenerator.position, Quaternion.identity);
		//	shoot_cool_left = shoot_cool_max;
		//	a.GetComponent<Player_Bullet>().move_dir = AimDetected();
		//	Debug.Log("왼11");
		//}
		//else if (shoot_cool_right < 0 )
		//{
		//	Quaternion q = Quaternion.Euler(AimDetected() - rightBulletGenerator.position + new Vector3(90, 0, 0) );
		//	var a = Instantiate(ObjectPool.instance.prefab_bullet, rightBulletGenerator.position, Quaternion.identity);
		//	shoot_cool_right = shoot_cool_max;
		//	a.GetComponent<Player_Bullet>().move_dir = AimDetected();
		//	Debug.Log("우22");
		//}
		
		



	}



	void Start()
    {
		//Cursor.visible = false;;
		//Cursor.lockState = CursorLockMode.Locked;
        stateMachine.cur_state.Enter();
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


		//Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.blue, 30f);
		shoot_cool_left -= Time.deltaTime;
		shoot_cool_right -= Time.deltaTime;
		shoot_cool_total -= Time.deltaTime;
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
		
		// 화면 중앙을 조준 위치로 설정합니다.
		RaycastHit hit;

		// 레이를 발사하고 물체에 부딪히면 물체의 위치를 가져옵니다.
		
		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			Vector3 objectPosition = hit.point;
			//Debug.Log("중앙에 있는 물체의 위치: " + objectPosition + " " + hit.collider.gameObject.name);
			return objectPosition;
		}

		
		return Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane));



	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(groundCheck1.position, 0.5f);

		//Gizmos.DrawLine(leftBulletGenerator.position, AimDetected()); 
		//ray = new Ray(firePos.position, dir);
	}
}
