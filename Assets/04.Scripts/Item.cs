using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	bool get_complete = false;
	public Canvas canvas_ui;
	public Camera canvas_cam;
	public float rotate_speed = 2.5f;

	public GameObject star;

	public ITEM item_type;

	

	private void Start()
	{
		transform.localScale *= 1.9f;
		canvas_ui = GameObject.Find("Canvas_UI").GetComponent<Canvas>();
		
	}

	//평소에 돌게
	private void FixedUpdate()
	{
		transform.Rotate(0, rotate_speed, 0);
	}


	//먹을 수 있게
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
		rotate_speed = 25f;

		Vector3 des_point = new Vector3(-600,0,0);

		transform.parent = canvas_ui.transform;
		//RectTransform rt = 

		yield return null;



		//while (transform.localScale.x > 0.01f)
		//{
		//	transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 0.1f);
		//	yield return new WaitForSeconds(0.1f);
		//}

		while (transform.localScale.x > 0.1f)
		{
			//transform.localPosition += new Vector3(0, 12f, 0);
			transform.localScale -= new Vector3(15f, 15f, 15f);
			//transform.position += new Vector3(0, 0.01f, 0);//
			//Vector3 cur_point = Camera.main.WorldToScreenPoint(transform.position);
			transform.localPosition = Vector3.Lerp(transform.localPosition, des_point , 0.2f);
			//transform.position = Vector3.Lerp(transform.position, cur_point, 0.1f);
			//transform.localScale -= new Vector3(0.02f, 0.02f, 0.02f);
			yield return null;
		}

		if (GameManager.instance.current_item.Contains(item_type))
		{
			yield break;
		}
		else
		{
			des_point = new Vector3(-833 + GameManager.instance.current_item.Count * 150, -384, 0);
			GameManager.instance.current_item.Add(item_type);
		}

		var a = Instantiate(ObjectPool.instance.prefab_item_trail_in_canvas, des_point, Quaternion.identity);
		a.transform.parent = canvas_ui.transform;
		a.transform.localPosition = new Vector3(-600,0,0);
		a.transform.localScale *= 0.001f;
		yield return new WaitForSeconds(1.5f);
		while (Vector3.Distance(a.transform.localPosition, new Vector3(-500, -500, 0) ) > 1)
		{
			
			a.transform.localPosition = Vector3.Lerp(a.transform.localPosition, des_point, 0.1f);
			yield return null;//
		}

		Destroy(a);
		

		Debug.Log("별 생성하면서 그쪽으로 들어가게");

	}

}
