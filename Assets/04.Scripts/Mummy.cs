using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy : MonoBehaviour
{

    public bool attack_done = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
            yield return new WaitForSeconds(0.3f);

        }

        attack_done = true;


    }
}
