using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject cube;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition) + "red" );
            
            Instantiate(cube, Camera.main.ViewportToWorldPoint(Camera.main.ScreenToViewportPoint(Input.mousePosition)), Quaternion.identity);
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition) + " blue");//
        }
    }
}
