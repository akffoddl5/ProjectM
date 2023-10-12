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

	private void Start()
	{
        anim = GetComponent<Animator>();
	}

	public virtual void Damage(float _damage) { }

    public virtual void Die() { }
}
