using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public float hp;
    public float hp_max;
    public Slider hp_slider;
    public Text hp_text;
    public Animator anim;
    public GameObject player;

	public GameObject have_item;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	private void Start()
	{
        anim = GetComponent<Animator>();
		
		
	}

	public virtual void Damage(float _damage) {
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

    public virtual void Die() {
		agent.speed = 0f;
		anim.SetBool("Die", true);
		Destroy(gameObject, 1.5f);
	}
}
