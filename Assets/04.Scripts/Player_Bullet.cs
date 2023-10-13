using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Player_Bullet : MonoBehaviour
{

    public Vector3 move_dir;
    public float move_speed = 25f;
	private Rigidbody rb;
	public float damage;
	public float hitOffset = 0f;
	public bool UseFirePointRotation;
	public Vector3 rotationOffset = new Vector3(0, 0, 0);
	public GameObject hit;
	public GameObject flash;
	public GameObject[] Detached;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		damage = 3f;
		transform.LookAt(move_dir);

		if (flash != null)
		{
			//Instantiate flash effect on projectile position
			var flashInstance = Instantiate(flash, transform.position, Quaternion.identity);
			flashInstance.transform.forward = gameObject.transform.forward;

			//Destroy flash effect depending on particle Duration time
			var flashPs = flashInstance.GetComponent<ParticleSystem>();
			if (flashPs != null)
			{
				Destroy(flashInstance, flashPs.main.duration);
			}
			else
			{
				var flashPsParts = flashInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
				Destroy(flashInstance, flashPsParts.main.duration);
			}
		}

		Destroy(gameObject, 5f);
		//Instantiate(ObjectPool.instance.prefab_explode, transform.position, Quaternion.identity);
	}

	void Update()
    {
		//	Vector3 _dir = move_dir - transform.position;
		//transform.position = (_dir).normalized * move_speed * Time.deltaTime;
		//transform.position += transform.forward * (move_speed * Time.deltaTime); 
		transform.position = Vector3.MoveTowards(transform.position, move_dir, 0.95f);

	}


	void OnCollisionEnter(Collision collision)
	{
		//Lock all axes movement and rotation
		rb.constraints = RigidbodyConstraints.FreezeAll;

		ContactPoint contact = collision.contacts[0];
		Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		Vector3 pos = contact.point + contact.normal * hitOffset;

		//Spawn hit effect on collision
		if (hit != null)
		{
			//Debug.Log("flag1");
			var hitInstance = Instantiate(hit, pos, rot);
			if (UseFirePointRotation) { hitInstance.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, 180f, 0); }
			else if (rotationOffset != Vector3.zero) { hitInstance.transform.rotation = Quaternion.Euler(rotationOffset); }
			else { hitInstance.transform.LookAt(contact.point + contact.normal); }

			//Destroy hit effects depending on particle Duration time
			var hitPs = hitInstance.GetComponent<ParticleSystem>();
			if (hitPs != null)
			{
				Destroy(hitInstance, hitPs.main.duration);
			}
			else
			{
				var hitPsParts = hitInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
				Destroy(hitInstance, hitPsParts.main.duration);
			}
		}

		//Removing trail from the projectile on cillision enter or smooth removing. Detached elements must have "AutoDestroying script"
		foreach (var detachedPrefab in Detached)
		{
			if (detachedPrefab != null)
			{
				detachedPrefab.transform.parent = null;
				Destroy(detachedPrefab, 1);
			}
		}


		if (collision.gameObject.CompareTag("Enemy"))
		{
			//Debug.Log("enemy ´Â ¸Â¾Æ2" + collision.gameObject.name);

			collision.gameObject.GetComponent<Enemy>().Damage(damage * GameManager.instance.player_att);
		}
		else if (collision.gameObject.CompareTag("Enemy_head"))
		{
			collision.gameObject.GetComponentInParent<Enemy>().Damage(damage * GameManager.instance.player_att * 1.4f);
		}

		//Destroy projectile on collision
		Destroy(gameObject);
	}

	//void OnCollisionEnter(Collision collision)
	//{

		

	//}
}
