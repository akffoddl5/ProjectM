using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : Enemy
{
    
    void Start()
    {
        hp_max = 150;
        hp = hp_max;
        hp_text.text = hp_max + "/" + hp_max;
        hp_slider.maxValue = hp_max;
    }

    void Update()
    {
        
    }

    public override void Damage(float _damage)
    {
       
        Debug.Log("damage " + _damage);
        hp -= _damage;
        hp_text.text = Mathf.Clamp(0, 0, hp_max) + "/" + hp_max;
        hp_slider.value = hp;

        if (hp <= 0)
        {
            hp = 0;
            Die();

        }
    }

    public override void Die()
    {
        anim.SetBool("Die", true);
        Destroy(gameObject,3f);
    }
}
