using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCraftController : MonoBehaviour
{
    public GameObject airplane;
    public Vector3 dir;
    public float speed;
    public float max_speed;
    public GameObject player;
    public GameObject flash;
    public GameObject skeleton;

    
    void Start()
    {
        dir = airplane.transform.forward;
        StartCoroutine(ISpeedUp());
        player.GetComponent<Animator>().Play("AIR");
        Debug.Log("AIR init");
    }

    void Update()
    {
        airplane.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator ISpeedUp()
    {
        while (true){
            speed += 0.2f;
            yield return null;
            if (speed > max_speed) break;

        }

        yield break;
    }

    public void TakeOff() {
        airplane.transform.Rotate(new Vector3(-50, 0, 0));    
    }

    public void DropSkeleton()
    {
        skeleton.transform.parent = null;
	}

    public void FlashOn()
    {
        Destroy(Instantiate(flash, airplane.transform.position, Quaternion.identity) , 1f);
        airplane.SetActive(false);
        //airplane.transform.position = new Vector3(-1000, -1000, -1000);//


        //æ¿ ¿Ãµø
        
    }
}
