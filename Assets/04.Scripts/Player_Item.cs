using Autodesk.Fbx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Player_Item : MonoBehaviour
{
    public Dictionary<ITEM, GameObject> item_dic = new Dictionary<ITEM, GameObject>();
    public List<GameObject> items = new List<GameObject>();
	public GameObject item_gate = null;

	private void Start()
	{
		item_dic.Add(ITEM.WING_ANGEL, items[0]);
		item_dic.Add(ITEM.WING_DEMON, items[1]);
		item_dic.Add(ITEM.SHOES, items[2]);
		//item_dic.Add(ITEM.WING_ANGEL, items[3]);
		item_dic.Add(ITEM.BELT, items[4]);
		item_dic.Add(ITEM.GLASSES, items[5]);
		item_dic.Add(ITEM.PARTYHAT, items[6]);
	}

	private void Update()
	{
		if (item_gate != null)
		{
			item_gate.transform.position = transform.position;
		}
	}

	public void Visual_Item(ITEM item)
	{
		item_dic[item].SetActive(true);
		item_gate = Instantiate(ObjectPool.instance.prefab_gate, transform.position, Quaternion.identity);

		if(item == ITEM.SHOES){
			items[3].SetActive(true);
		}
	}



}


