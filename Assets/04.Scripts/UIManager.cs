using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
	public static UIManager instance;

	public Slider option_left_slider;
	public Slider option_right_slider;
	public Image option_left_graph;
	public Image option_right_graph;
	public Text option_left_text;
	public Text option_right_text;
	public GameObject canvas_option;
	public GameObject menu;
	public GameObject option;
	public GameObject exit;
	public GameObject soloStage;
	public GameObject endTimeLine;

	//사운드 옵션
	public Slider option_fx;
	public Slider option_music;

	//체력
	public Image health_bar;
	public Text health_text;

	//라운드
	public Image level_bar;
	public Text level_text;
	public Text round_text;

	public PlayerControl player;

	//public void LevelSet(int _level, float _current_per)
	//{
		
	//}


	private void Awake()
	{
		if (instance != null) Destroy(instance.gameObject);
		instance = this;

		
	}




	private void Update()
	{
		option_left_graph.fillAmount = option_left_slider.value / 2;
		option_right_graph.fillAmount = option_right_slider.value / 2;

		option_left_text.text = string.Format("{0:N2}", option_left_slider.value);
		option_right_text.text = string.Format("{0:N2}", option_right_slider.value);

		player.vcam_POV.m_VerticalAxis.m_MaxSpeed = 100 + 350 * option_left_slider.value;
		player.vcam_POV.m_HorizontalAxis.m_MaxSpeed = 100 + 350 * option_left_slider.value;
		player.aimCam_POV.m_HorizontalAxis.m_MaxSpeed = 100 + 350 * option_right_slider.value;
		player.aimCam_POV.m_VerticalAxis.m_MaxSpeed = 100 + 350 * option_right_slider.value;

		//채력 UI
		health_bar.fillAmount = (player.hp / player.hp_max);
		health_text.text = player.hp + "/" + player.hp_max;


		//옵션으로 사운드 조절
		SoundManager.instance.audios[0].volume = option_music.value;
		for (int i = 0; i < SoundManager.instance.audios.Length; i++)
		{
			if (i != 0) SoundManager.instance.audios[i].volume = option_fx.value;
		}

		
	}

	public void OptionClose()
	{
		canvas_option.SetActive(false);
	}

	public void OptionOpen()
	{
		canvas_option.SetActive(true);
		option.SetActive(false);
		exit.SetActive(false);
		menu.SetActive(true);
	}

	public void MouseAccelOpen()
	{
		canvas_option.SetActive(true);
		option.SetActive(true);
		exit.SetActive(false);
		menu.SetActive(false);
	}

	public void BackButton()
	{
		canvas_option.SetActive(true);
		option.SetActive(false);
		exit.SetActive(false);
		menu.SetActive(true);
	}

	public void ExitTry()
	{
		canvas_option.SetActive(true);
		option.SetActive(false);
		menu.SetActive(false);
		exit.SetActive(true);
	}

	public void GameExit()
	{
		Application.Quit();
	}

	public void SoloCor(int _start, int _end)
	{
		StartCoroutine(CorSoloInit(_start, _end));
	}

	IEnumerator CorSoloInit(int _start, int _end) {
		soloStage.transform.localScale = Vector3.one * _start;
		while (true)
		{
			soloStage.transform.localScale
				= Vector3.MoveTowards(soloStage.transform.localScale, Vector3.one * _end, 25);
			yield return null;

			if (Vector3.Distance(soloStage.transform.localScale, Vector3.one * _end) < 10) break;
		}


		yield return new WaitForSeconds(3f);

		while (true)
		{
			soloStage.transform.localScale
				= Vector3.MoveTowards(soloStage.transform.localScale, Vector3.one * 120, 25);
			yield return null;

			if (Vector3.Distance(soloStage.transform.localScale, Vector3.one * 120) < 10) break;
		}

		endTimeLine.SetActive(true);
		yield break;
	}

	public void GoLobbyScene()
	{
		SceneManager.LoadScene(0);
	}
}
