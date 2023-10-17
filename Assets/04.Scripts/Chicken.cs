using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    public Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
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
