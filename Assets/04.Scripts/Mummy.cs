using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.AI;

public class Mummy : Enemy
{
	public GameObject attack_generator;
	public bool attack_done = false;
	public GameObject tornado;
    public GameObject tornado_obj;
    public GameObject tornado_bullet;

    public float att;

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

    public void Cor_Blink(float _time, GameObject _red_line)
    {
        StartCoroutine(IRed_line_blink(_time, _red_line));
    }

    IEnumerator IRed_line_blink(float _time, GameObject _red_line)
    {
        while (_time > 0)
        {
            _time -= Time.deltaTime;

            _red_line.SetActive(!_red_line.activeSelf);
            if (_time <= 0)
            {
				attack_done = true;
			}
            yield return new WaitForSeconds(0.01f);
        }
        attack_done = true;

	}

    public void AttackMotion()
    {
		tornado_obj = Instantiate(tornado, attack_generator.transform.position, Quaternion.identity);
        Destroy(tornado_obj, 2.65f);
		//a.transform.LookAt(player.transform.position);
		


		StartCoroutine(MakeBig(tornado_obj));
	}

    public void Shoot(Vector3 _dir)
    {
        //Debug.Log("shoot" + player.transform.position + " À¸·Î \n" + (player.transform.position - attack_generator.transform.position));

        //var b = Quaternion.LookRotation(player.transform.position - attack_generator.transform.position);
        //Debug.Log(b);

        var a = Instantiate(tornado_bullet, attack_generator.transform.position, Quaternion.identity);
        a.GetComponent<HS_ProjectileMover>().att = att;
        a.GetComponent<HS_ProjectileMover>()._dir = _dir;

        //a.transform.LookAt(player.transform);
        
    }

    IEnumerator MakeBig(GameObject a) {
        if (a == null) yield break;
        while (a.transform.localScale.x < 0.4f)
        {
            a.transform.localScale += new Vector3(0.003f, 0.003f, 0.003f);

            //yield return new WaitForSeconds(0.1f);
            yield return null;
		}
    }

	public override void Die()
	{
		agent.speed = 0f;
		anim.SetBool("Die", true);
		Destroy(gameObject, 5f);


	}
}
