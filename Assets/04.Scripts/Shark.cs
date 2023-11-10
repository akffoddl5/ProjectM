using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Shark : Enemy
{
	public GameObject attack_generator;
	Rigidbody rb;
	public float speed;
	
	public float att;


	void Start()
    {
		//hp_max = 300;
		//hp = hp_max;
		//hp_text.text = hp_max + "/" + hp_max;
		//hp_slider.maxValue = hp_max;
		//hp_slider.value = hp;//

		//hp_slider.gameObject.GetComponent<RectTransform>().localScale = new Vector3(hp_max * 0.003f, hp_slider.gameObject.GetComponent<RectTransform>().localScale.y, hp_slider.gameObject.GetComponent<RectTransform>().localScale.z);

		rb = GetComponent<Rigidbody>();
		
	}

    void Update()
    {
		var a = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) - transform.position;
		transform.LookAt(player.transform);

		if (Vector3.Distance(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), transform.position) > 15f)
		{
			rb.velocity = a.normalized * speed * Time.deltaTime;
		}
		else if (Vector3.Distance(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), transform.position) < 5f)
		{
			rb.velocity = -a.normalized * speed * Time.deltaTime;
		}


		//===============


		//transform.localRotation = Quaternion.Euler(a);
		//transform.localRotation = Quaternion.LookRotation(a);
		//transform.Translate(new Vector3(0,0,1) * speed * Time.deltaTime / 60);
		//player.transform.position//
	}

}
