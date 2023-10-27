using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	bool get_complete = false;
	public Canvas canvas_ui;
	public Camera canvas_cam;
	

	private void Start()
	{
		transform.localScale *= 1.9f;
		canvas_ui = GameObject.Find("Canvas_UI").GetComponent<Canvas>();
		
	}

	//��ҿ� ����
	private void FixedUpdate()
	{
		transform.Rotate(0, 2.5f, 0);
	}


	//���� �� �ְ�
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !get_complete )
		{
			StartCoroutine(GetItem());
		}
	}

	IEnumerator GetItem()
	{
		get_complete = true;
		
		Vector3 des_point = Vector3.zero;

		
		while (transform.localScale.x > 0.1f)
		{
			Vector3 cur_point = Camera.main.WorldToScreenPoint(transform.position);
			transform.position = Vector3.Lerp(cur_point, des_point , 0.1f);
			transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
			yield return null;
		}
		yield return null;
		Debug.Log("�� �����ϸ鼭 �������� ����");
		
	}

}
