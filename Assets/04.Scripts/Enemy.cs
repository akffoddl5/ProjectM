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
	bool isDie = false;

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
		if (isDie) return;
		agent.speed = 0f;
		anim.SetBool("Die", true);
		Destroy(gameObject, 1.5f);

		GetComponent<Collider>().enabled = false;

		if (have_item != null)
		{
			Debug.Log("item 스폰해야함1" + have_item.name);
			Instantiate(have_item, transform.position + new Vector3(0,1,0), Quaternion.identity);
			Instantiate(ObjectPool.instance.prefab_item_portal, transform.position, Quaternion.identity);
		}
		isDie = true;
	}
}
