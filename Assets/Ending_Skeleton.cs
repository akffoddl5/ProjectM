using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class Ending_Skeleton : MonoBehaviour
{
    public GameObject des;
    public float speed;
    Rigidbody rb;
    bool arrive = false;
    bool air_arrive = false;
    bool get_des_mode = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		Vector3 dir = des.transform.position - transform.position;
		if (!get_des_mode)
        {
        
		    transform.LookAt(new Vector3(des.transform.position.x, transform.position.y, des.transform.position.z));//
            
            rb.velocity = new Vector3(dir.normalized.x, 0, dir.normalized.z) * speed * Time.deltaTime + Vector3.up * rb.velocity.y;
        }
        else
        {
			rb.velocity = dir.normalized * speed * Time.deltaTime;
		}

    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.name == "aircraft" && !air_arrive)
        {
            air_arrive = true;//
			speed = 0;
            GetComponent<Animator>().Play("Jump");
            
        }
		else if (other.gameObject.name == "des")
		{
            Debug.Log("des enter");
            speed = 0;
            transform.parent = des.transform.parent;
            arrive = true;
		}
	}

    public void JumpTrigger()
    {
        speed = 400f;//
		rb.AddForce(Vector3.up * 400);
        StartCoroutine(IGetDes());
	}

   

    IEnumerator IGetDes()
    {
        yield return new WaitForSeconds(0.2f);
        get_des_mode = true;
    }
}
