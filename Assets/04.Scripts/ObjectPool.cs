using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ITEM {
	WING_ANGEL,
	WING_DEMON,
	SHOES,
	BELT,
	GLASSES,
	PARTYHAT,
	

}

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

	public GameObject prefab_bullet;
	public GameObject prefab_explode;
	public GameObject prefab_gate;
	public GameObject prefab_item_portal;
	public GameObject prefab_item_trail;


	public GameObject[] prefab_items;
	public Dictionary<ITEM, GameObject> item_dic = new Dictionary<ITEM, GameObject>();

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		item_dic.Add(ITEM.WING_ANGEL, prefab_items[0]);
		item_dic.Add(ITEM.WING_DEMON, prefab_items[1]);
		item_dic.Add(ITEM.SHOES, prefab_items[2]);
		item_dic.Add(ITEM.BELT, prefab_items[3]);
		item_dic.Add(ITEM.GLASSES, prefab_items[4]);
		item_dic.Add(ITEM.PARTYHAT, prefab_items[5]);

		//item_dic[ITEM.WING_ANGEL] = prefab_items[0];
		//item_dic[ITEM.WING_DEMON] = prefab_items[1];
		//item_dic[ITEM.SHOES] = prefab_items[2];
		//item_dic[ITEM.BELT] = prefab_items[3];
		//item_dic[ITEM.GLASSES] = prefab_items[4];
		//item_dic[ITEM.PARTYHAT] = prefab_items[5];
	}




}
