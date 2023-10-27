using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

	public Transform[] spawns;
	public Stage[] stages = new Stage[4];

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

	

	public void Spawn(int _st)
	{
		Stage _stage = stages[_st];
		int spawn_size = spawns.Length;
		Debug.Log(_stage + " " );
		int enemy_size = _stage.enemy_list.Length;
		HashSet<int> real_spawn = new HashSet<int>();

		while (real_spawn.Count != _stage.enemy_list.Length)
		{
			int rand = Random.Range(0, _stage.enemy_list.Length);
			real_spawn.Add(rand);
		}

		Debug.Log(real_spawn.Count + " ½ºÆù ´Ù Ã¡°í ½ºÆùÇÏ¸é´ï");



		int idx = -1;
		foreach (var a in real_spawn)
		{
			idx++;
			var obj =Instantiate(_stage.enemy_list[a], spawns[a].position, Quaternion.identity);
			Instantiate(ObjectPool.instance.prefab_gate, spawns[a].position, Quaternion.identity);
			if (idx == 0 || idx == 1 || idx ==2)
			{
				
				int item_num = ObjectPool.instance.item_dic.Keys.Count;
				int rand = Random.Range(0, item_num - 1);
				obj.GetComponent<Enemy>().have_item = ObjectPool.instance.item_dic[(ITEM)rand];
			}
		}
		
	}

	
}
