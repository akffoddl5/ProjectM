using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LoadSceneManager : MonoBehaviour
{
	public GameObject canvas_option;
	//public GameObject menu;
	//public GameObject option;
	public GameObject exit;

	public GameObject ninja;
	public GameObject item_scroll;
	public GameObject item_scroll_cam;
	public GameObject main_cam;

	//main UI
	public GameObject main_text;
	public GameObject main_game_start_button;
	public GameObject main_item_button;
	public GameObject main_exit_button;

	


	// UI러프로 움직이기
	IEnumerator CorLerp(GameObject gameObject, Vector3 start_pos, Vector3 des_pos)
	{
		RectTransform RT = gameObject.GetComponent<RectTransform>();
		RT.localPosition = start_pos;
		while (Vector3.Distance(RT.localPosition, des_pos) > 1f)
		{
			//Debug.Log(Vector3.Distance(RT.localPosition, des_pos));
			RT.localPosition = Vector3.Lerp(RT.localPosition, des_pos, 0.05f);
			//yield return new WaitForSeconds(0.5f);
			yield return new WaitForSeconds(0.01f);
		}

		yield break;
	}


	public void ExitTry()
	{
		Debug.Log("red2");
		canvas_option.SetActive(true);
		//option.SetActive(false);
		//menu.SetActive(false);
		exit.SetActive(true);
	}

	public void OptionClose()
	{
		canvas_option.SetActive(false);
	}


	public void GameExit()
	{
		Application.Quit();
	}

	public void ItemClick()
	{
		ninja.GetComponent<Animator>().Play("Two Hand Spell Casting");
	}

	public void ItemScrollShow()
	{
		main_cam.SetActive(false);
		item_scroll_cam.SetActive(true);
		Debug.Log("scroll show22");
		item_scroll.SetActive(true);
		item_scroll.transform.localScale = new Vector3(1, 0, 1);
		StartCoroutine(CorLerp(main_text, new Vector3(0,359,0), new Vector3(0,765,0)));
		StartCoroutine(CorLerp(main_exit_button, new Vector3(-847, -388,0), new Vector3(-1176,104,0)));
		StartCoroutine(CorLerp(main_game_start_button, new Vector3(659,-206,0), new Vector3(1242,-206, 0)));
		StartCoroutine(CorLerp(main_item_button, new Vector3(659, -383,0), new Vector3(1242, -383,0)));
		StartCoroutine(ScrollOn());
	}

	IEnumerator ScrollOn()
	{
		while (item_scroll.transform.localScale.y < 1)
		{
			item_scroll.transform.localScale += new Vector3(0, 0.02f, 0);
			yield return null;
		}
		yield break;
	}

	public void ScrollBack()
	{
		Debug.Log("scroll back");
		main_cam.SetActive(true);
		item_scroll_cam.SetActive(false);
		ninja.GetComponent<Animator>().Play("Two Hand Spell Casting (1)");
	}

	public void GameStart()
	{

	}

}
