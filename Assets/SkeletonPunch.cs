using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonPunch : MonoBehaviour
{

	public float att = 15f;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			other.gameObject.GetComponent<PlayerControl>().Damage(att);
		}
	}
}
