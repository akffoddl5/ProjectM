using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public Transform cam;

	
		
	void Update()
    {
        transform.LookAt(cam);
        transform.Rotate(0,180,0);
    }
}
