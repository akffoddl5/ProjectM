using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_Solo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		SoloCor(5000, 1000);
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SoloCor(int _start, int _end)
	{
		StartCoroutine(CorSoloInit(_start, _end));
	}

	IEnumerator CorSoloInit(int _start, int _end)
	{
		transform.localScale = Vector3.one * _start;
		while (true)
		{
			transform.localScale
				= Vector3.MoveTowards(transform.localScale, Vector3.one * _end, 150);
			yield return null;

			if (Vector3.Distance(transform.localScale, Vector3.one * _end) < 10) break;
		}


		yield return new WaitForSeconds(3f);

		while (true)
		{
			transform.localScale
				= Vector3.MoveTowards(transform.localScale, Vector3.one * 500, 25);
			yield return null;

			if (Vector3.Distance(transform.localScale, Vector3.one * 500) < 10) break;
		}

		yield break;
	}
}
