using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item_Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public string item_description = "?";
	public Text item_text;
	public Sprite item_img;
	public ITEM item_type;
	public bool open = false;

	private void Start()
	{
		if (PlayerPrefs.GetInt(item_type.ToString()) == 1)
		{
			gameObject.GetComponent<Image>().sprite = item_img;
			gameObject.GetComponentInChildren<Text>().text = "";
			gameObject.GetComponent<Image>().color = Color.white;
			open = true;

		}
		Debug.Log(" �����տ�1 �ֳ� ? <>>> " + item_type.ToString() + " "  + PlayerPrefs.GetInt(item_type.ToString()));
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (open)
			item_text.text = item_description;
		else
			item_text.text = "?";
		var a = GetComponent<Image>().color;
		a.a = 0.8f;
		GetComponent<Image>().color = a;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		var b = GetComponent<Image>().color;
		b.a = 0.5f;
		GetComponent<Image>().color = b;//
		Debug.Log("exit" + gameObject.name + " " + GetComponent<Image>().color.a);
	}

	private void Update()
	{
		
	}

}
