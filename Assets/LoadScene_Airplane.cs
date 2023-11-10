using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene_Airplane : MonoBehaviour
{
    public Transform des;
    Vector3 dir;
    public float speed;
    Rigidbody rb;
    public GameObject boom;
    

    void Start()
    {
        transform.LookAt(des);
        rb = GetComponent<Rigidbody>();
        dir = des.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void FixedUpdate()
	{

        rb.velocity = dir * Time.deltaTime * speed;

        //Debug.Log(dir.normalized * speed + " " + des.position  + " " + dir.normalized.magnitude + " " + Vector3.Distance(des.position, transform.position)); ;
        //transform.Translate(dir.normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Enemy"))
        {
            var a = Instantiate(boom, des.position, Quaternion.identity);
            Destroy(a,4);
            
            StartCoroutine(LoadScene());
            //gameObject.SetActive(false);
            //Destroy(gameObject);

            GameObject.Find("Ninja_").GetComponent<Animator>().Play("RUN");

            Debug.Log("ÁøÂ¥ Æã");
        }

        var c = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var b in c)
        {
            if(b.GetComponent<Animator>() != null)
                b.GetComponent<Animator>().SetBool("Run",true);
            //Destroy(b, 1);
            //b.SetActive(false);
        }
	}

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.2f);
		transform.position = new Vector3(-100, -100, -100);
		Debug.Log("flag0");
        yield return new WaitForSeconds(4);
        Debug.Log("flag1");
        SceneManager.LoadScene(1);
    }
}
