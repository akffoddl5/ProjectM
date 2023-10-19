using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Item_Button : MonoBehaviour, IPointerEnterHandler
{
	public string item_description = "?";
	public Text item_text;

	public void OnPointerEnter(PointerEventData eventData)
	{
		item_text.text = item_description;
	}

	

	private void Update()
	{
		
	}

}
