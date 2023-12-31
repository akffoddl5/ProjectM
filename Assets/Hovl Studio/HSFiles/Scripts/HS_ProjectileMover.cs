﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HS_ProjectileMover : MonoBehaviour
{
    float speed ;
    public float hitOffset = 0f;
    public bool UseFirePointRotation;
    public Vector3 rotationOffset = new Vector3(0, 0, 0);
    public GameObject hit;
    public GameObject flash;
    private Rigidbody rb;
    public GameObject[] Detached;
    public Vector3 player_pos;
    public Vector3 _dir;
	Vector3 target;

    public float att;

    void Start()
    {
        speed = 20f;
		target = GameObject.FindWithTag("Player").transform.position + new Vector3(0, 0.5f, 0);
		//player_pos = GameObject.FindWithTag("Player").transform.position;
		_dir = (target - transform.position).normalized;
		rb = transform.GetComponent<Rigidbody>();
		
		//if (flash != null)
		//{
		//    //Instantiate flash effect on projectile position
		//    var flashInstance = Instantiate(flash, transform.position, Quaternion.identity);
		//    flashInstance.transform.forward = gameObject.transform.forward;

		//    //Destroy flash effect depending on particle Duration time
		//    var flashPs = flashInstance.GetComponent<ParticleSystem>();
		//    if (flashPs != null)
		//    {
		//        Destroy(flashInstance, flashPs.main.duration);
		//    }
		//    else
		//    {
		//        var flashPsParts = flashInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
		//        Destroy(flashInstance, flashPsParts.main.duration);
		//    }
		//}
		//Destroy(gameObject,5);
	}

    void FixedUpdate ()
    {
		transform.rotation = Quaternion.LookRotation(_dir);
		//transform.LookAt(target);//
		if (speed != 0)
        {
            //rb.velocity = transform.forward * speed;
            rb.velocity = _dir * speed;
            //transform.position += transform.forward * (speed * Time.deltaTime);         
        }
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.name);
		//Lock all axes movement and rotation//
		rb.constraints = RigidbodyConstraints.FreezeAll;
		speed = 0;//

		if (hit != null)
		{
			var hitInstance = Instantiate(hit, transform.position, Quaternion.identity);
			if (UseFirePointRotation) { hitInstance.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, 180f, 0); }
			else if (rotationOffset != Vector3.zero) { hitInstance.transform.rotation = Quaternion.Euler(rotationOffset); }
			//else { hitInstance.transform.LookAt(contact.point + contact.normal); }

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


		if (other.CompareTag("Player"))
		{
			


			other.gameObject.GetComponent<PlayerControl>().Damage(att);
			Debug.Log("대미지줌 " + att);//
		}

		//Instantiate(flash, transform.position, Quaternion.identity);
		//gameObject.SetActive(false);
		Destroy(gameObject);

	}

	void OnCollisionEnter(Collision collision)
	{
	//	Debug.Log("collision enter");
	//	//Lock all axes movement and rotation
	//	rb.constraints = RigidbodyConstraints.FreezeAll;
	//	speed = 0;

	//	ContactPoint contact = collision.contacts[0];
	//	Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
	//	Vector3 pos = contact.point + contact.normal * hitOffset;

	//	//Spawn hit effect on collision
	//	if (hit != null)
	//	{
	//		var hitInstance = Instantiate(hit, pos, rot);
	//		if (UseFirePointRotation) { hitInstance.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, 180f, 0); }
	//		else if (rotationOffset != Vector3.zero) { hitInstance.transform.rotation = Quaternion.Euler(rotationOffset); }
	//		else { hitInstance.transform.LookAt(contact.point + contact.normal); }

	//		//Destroy hit effects depending on particle Duration time
	//		var hitPs = hitInstance.GetComponent<ParticleSystem>();
	//		if (hitPs != null)
	//		{
	//			Destroy(hitInstance, hitPs.main.duration);
	//		}
	//		else
	//		{
	//			var hitPsParts = hitInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
	//			Destroy(hitInstance, hitPsParts.main.duration);
	//		}
	//	}

	//	//Removing trail from the projectile on cillision enter or smooth removing. Detached elements must have "AutoDestroying script"
	//	foreach (var detachedPrefab in Detached)
	//	{
	//		if (detachedPrefab != null)
	//		{
	//			detachedPrefab.transform.parent = null;
	//			Destroy(detachedPrefab, 1);
	//		}
	//	}
	//	//Destroy projectile on collision
	//	Destroy(gameObject);
	}
}
