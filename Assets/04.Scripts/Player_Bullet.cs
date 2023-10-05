using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{

    public Vector3 move_dir;
    public float move_speed = 5f;
    
    void Update()
    {
        //transform.position = transform.position + move_dir * move_speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, move_dir, 0.1f);
	}
}
