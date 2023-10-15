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
		hp_max = 700;
        hp = hp_max;
        hp_text.text = hp_max + "/" + hp_max;
        hp_slider.maxValue = hp_max;
        hp_slider.value = hp;

		hp_slider.gameObject.GetComponent<RectTransform>().localScale = new Vector3(hp_max * 0.003f, hp_slider.gameObject.GetComponent<RectTransform>().localScale.y, hp_slider.gameObject.GetComponent<RectTransform>().localScale.z);
    }

    void Update()
    {
        
    }

    public override void Damage(float _damage)
    {
       
        //Debug.Log("damage " + _damage);
        hp -= _damage;
        
        hp_text.text = (int)Mathf.Clamp(hp, 0, hp_max) + "/" + hp_max;
        hp_slider.value = hp;

        if (hp <= 0) hp_slider.gameObject.SetActive(false);

        if (hp <= 0)
        {
            hp = 0;
            Die();

        }
    }

    public override void Die()
    {
        agent.speed = 0f;
		anim.SetBool("Die", true);
        Destroy(gameObject,1.5f);
    }
}
