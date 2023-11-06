using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	bool get_complete = false;
	public Canvas canvas_ui;
	public Camera canvas_cam;
	public float rotate_speed = 2.5f;
	public GameObject star;
	public ITEM item_type;

	public GameObject item_scrollView_content;

	public Player_Item player_item;

	

	private void Start()
	{
		transform.localScale *= 1.9f;
		canvas_ui = GameObject.Find("Canvas_UI").GetComponent<Canvas>();
		item_scrollView_content = GameObject.Find("Item_Content");
		player_item = GameObject.Find("Player").GetComponent<Player_Item>();

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
		while (Vector3.Distance(a.transform.localPosition, des_point) > 10)
		{
			//Debug.Log("red" + Vector3.Distance(a.transform.localPosition, des_point));

			a.transform.localPosition = Vector3.Lerp(a.transform.localPosition, des_point, 0.1f);
			yield return null;
		}

		Destroy(a);
		Sprite item_image = ObjectPool.instance.item_dic_image[item_type];
		var _button = Instantiate(ObjectPool.instance.prefab_item_button);
		_button.transform.parent = item_scrollView_content.transform;
		_button.transform.localPosition = Vector3.zero;
		_button.GetComponent<Image>().sprite = item_image;
		_button.transform.localScale = Vector3.one;
		_button.transform.localRotation = Quaternion.identity;


		//item visual
		player_item.Visual_Item(item_type);

		//치명타 확률 증가
		if (item_type == ITEM.GLASSES)
		{
			GameManager.instance.critical_per += 20;
		}
		//공격력 증가
		else if (item_type == ITEM.BELT)
		{
			GameManager.instance.player_att += 2;
		}
		else if (item_type == ITEM.PARTYHAT)
		{
			GameObject.Find("Player").GetComponent<PlayerControl>().hp += 50;
			GameObject.Find("Player").GetComponent<PlayerControl>().hp_max += 50;
		}
		else if (item_type == ITEM.SHOES)
		{
			GameObject.Find("Player").GetComponent<PlayerControl>().speed *= 1.2f;
		}
		else if (item_type == ITEM.WING_ANGEL)
		{
			GameObject.Find("Player").GetComponent<PlayerControl>().can_jump_num++;
			GameObject.Find("Player").GetComponent<PlayerControl>().jump_power *= 1.2f;
		}
		else if (item_type == ITEM.WING_DEMON)
		{
			GameObject.Find("Player").GetComponent<PlayerControl>().dash_power *= 1.2f;
		}

		PlayerPrefs.SetInt(item_type.ToString(), 1);
		Debug.Log(" 프리팹에 저장 : " + PlayerPrefs.GetInt(item_type.ToString()));

	}

}
