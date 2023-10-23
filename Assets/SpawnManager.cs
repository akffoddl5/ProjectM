using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

	public Transform[] spawns;
	public Stage stage1;
	public Stage stage2;
	public Stage stage3;

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

	public void Spawn(Stage _stage)
	{
		int spawn_size = spawns.Length;
		int enemy_size = _stage.enemy_list.Length;
		HashSet<int> real_spawn = new HashSet<int>();

		while (real_spawn.Count != _stage.enemy_list.Length)
		{
			int rand = Random.Range(0, _stage.enemy_list.Length);
			real_spawn.Add(rand);
			
		}

		Debug.Log(real_spawn.Count + " ½ºÆù ´Ù Ã¡°í ½ºÆùÇÏ¸é´ï");
	}

	
}
