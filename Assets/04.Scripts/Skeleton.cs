using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : Enemy
{
	void Start()
    {
        
		agent = GetComponent<NavMeshAgent>();
        hp = hp_max;
        hp_text.text = hp_max + "/" + hp_max;
        hp_slider.maxValue = hp_max;
        hp_slider.value = hp;

		hp_slider.gameObject.GetComponent<RectTransform>().localScale = new Vector3(hp_max * 0.003f, hp_slider.gameObject.GetComponent<RectTransform>().localScale.y, hp_slider.gameObject.GetComponent<RectTransform>().localScale.z);
    }

    void Update()
    {
        
    }

    //public override void Damage(float _damage)
    //{
       
        
    //}

    //public override void Die()
    //{
        
    //}
}
