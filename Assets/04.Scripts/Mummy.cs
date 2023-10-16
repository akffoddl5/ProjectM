using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Mummy : Enemy
{
	public GameObject attack_generator;
	public bool attack_done = false;
	public GameObject tornado;
    public GameObject tornado_obj;
    public GameObject tornado_bullet;

	void Start()
    {
        
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
            yield return new WaitForSeconds(0.05f);
        }
        attack_done = true;

		
	}

    public void AttackMotion()
    {
		tornado_obj = Instantiate(tornado, attack_generator.transform.position, Quaternion.identity);
		//a.transform.LookAt(player.transform.position);
		


		StartCoroutine(MakeBig(tornado_obj));
	}

    public void Shoot()
    {
        Debug.Log("shoot");
        var a = Instantiate(tornado_bullet, attack_generator.transform.position, Quaternion.identity);
        
        
    }

    IEnumerator MakeBig(GameObject a) {
        while (a.transform.localScale.x < 0.4f)
        {
            a.transform.localScale += new Vector3(0.003f, 0.003f, 0.003f);

            //yield return new WaitForSeconds(0.1f);
            yield return null;
		}

        
    }
}
