using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark_Bullet : MonoBehaviour
{
    Vector3 target;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

        transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
        
    }
}
