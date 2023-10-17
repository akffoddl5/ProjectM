using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public Animator anim;
    public bool setRotate;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        if(!setRotate)
        transform.rotation = Quaternion.Euler(0, Random.Range(0,360), 0);
    }

    IEnumerator RandomAction()
    {
        while (true)
        {


            yield return new WaitForSeconds(Random.Range(3, 5));
        }

    }

    void Update()
    {
        
    }
}
