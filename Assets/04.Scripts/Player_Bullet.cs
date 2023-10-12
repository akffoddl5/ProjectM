using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{

    public Vector3 move_dir;
    public float move_speed = 25f;
	private Rigidbody rb;
	public float damage;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		damage = 3f;
		transform.LookAt(move_dir);

		//Instantiate(ObjectPool.instance.prefab_explode, transform.position, Quaternion.identity);
	}

	void Update()
    {
		//	Vector3 _dir = move_dir - transform.position;
		//transform.position = (_dir).normalized * move_speed * Time.deltaTime;
		//transform.position += transform.forward * (move_speed * Time.deltaTime); 
		transform.position = Vector3.MoveTowards(transform.position, move_dir, 0.5f);
	}

	

	void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("enemy ´Â ¸Â¾Æ2" + collision.gameObject.name);

			collision.gameObject.GetComponent<Enemy>().Damage(damage * GameManager.instance.player_att);
		}
		else if (collision.gameObject.CompareTag("Enemy_head"))
		{
			collision.gameObject.GetComponentInParent<Enemy>().Damage(damage * GameManager.instance.player_att * 1.4f) ;
		}


	}

}
