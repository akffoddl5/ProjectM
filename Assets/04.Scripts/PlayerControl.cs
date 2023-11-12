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
	public PlayerState dieState;

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
	public CinemachineVirtualCamera endingCam;
	public CinemachineTransposer vcam_trans;
	public CinemachineTransposer aimcam_trans;
	public CinemachinePOV vcam_POV;
	public CinemachinePOV aimCam_POV;
	public GameObject left_gun;
	public GameObject right_gun;
	
	

	public float rotationY;
	public float rotationY_aim;

	//������
	public float speed = 5f;
    public float jump_power = 500f;
	public float dash_power = 60f;
	public int can_jump_num = 1;
	public int current_jump_num = 0;

	//Ÿ�̸�
	public float shoot_cool_left;
	public float shoot_cool_right;
	public float shoot_cool_total;
	public bool shoot_left = true;
	public float shoot_cool_max = 0.3f;

	//Rig
	public GameObject body;

	//status
	public float hp;
	public float hp_max;
	
	


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
		dieState = new Player_Die("Die", stateMachine, this);

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
	}



	void Start()
    {
		stateMachine.cur_state.Enter();
	}

	void Update()
    {
		stateMachine.cur_state.Update();

		//if (Input.GetKeyDown(KeyCode.LeftAlt))
		//{
		//	Cursor.visible = !Cursor.visible;
			
		//	Cursor.lockState =  (CursorLockMode)((int)Cursor.lockState  ^ 1);
		//	Debug.Log(Cursor.lockState + "  << locked state");
		//}

		//ȭ�鰢 ���
		var state = vcam.State;
		var rotation = state.FinalOrientation;
		var euler = rotation.eulerAngles;
		rotationY = euler.y;
		var roundRotationY = Mathf.RoundToInt(rotationY);

		//Aimķ ȭ�鰢 ���
		var state_aim = aimCam.State;
		var rotation_aim = state_aim.FinalOrientation;
		var euler_aim = rotation_aim.eulerAngles;
		rotationY_aim = euler_aim.y;
		var roundRotationY_aim = Mathf.RoundToInt(rotationY_aim);


		//Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.blue, 30f);
		shoot_cool_left -= Time.deltaTime;
		shoot_cool_right -= Time.deltaTime;
		shoot_cool_total -= Time.deltaTime;
	}


	public Quaternion FlatRotation()
	{
		return Quaternion.Euler(0, rotationY, 0);
	}
	public Quaternion FlatRotation_aim()
	{
		
		return Quaternion.Euler(0, rotationY_aim, 0);
	}

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
		//return Camera.main.
		//PointToRay(Input.mousePosition).direction;
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
		Gizmos.DrawWireSphere(groundCheck1.position, 0.5f);

		//Gizmos.DrawLine(leftBulletGenerator.position, AimDetected()); 
		//ray = new Ray(firePos.position, dir);
	}

	public void Damage(float _damage)
	{
		hp -= _damage;
		if (hp < 0)
		{
			Die();
		}
	}

	public void Die()
	{
		stateMachine.ChangeState(dieState);

		GetComponent<PlayerControl>().endingCam.transform.parent = null;
		GetComponent<PlayerControl>().endingCam.gameObject.SetActive(true);
		gameObject.GetComponent<Collider>().enabled = false;

		UIManager.instance.SoloCor(5000, 1000);
		UIManager.instance.SoloCor(5000, 1000);

	}

	public void ThrowGun()
	{
		left_gun.transform.parent = null;//
		right_gun.transform.parent = null;
		left_gun.GetComponent<Rigidbody>().useGravity = true;
		right_gun.GetComponent<Rigidbody>().useGravity = true;
		left_gun.GetComponent<Rigidbody>().AddForce(transform.forward * 500 + Vector3.up * 200f);
		right_gun.GetComponent<Rigidbody>().AddForce(transform.forward * 700 + Vector3.up * 300f);
	}
}
