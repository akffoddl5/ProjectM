using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{

    public Vector3 move_dir;
    public float move_speed = 25f;

	private void Start()
	{
		Instantiate(ObjectPool.instance.prefab_explode, transform.position, Quaternion.identity);
	}

	void Update()
    {
	//	Vector3 _dir = move_dir - transform.position;
        //transform.position = (_dir).normalized * move_speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, move_dir, 0.9f);
		
	}
}
