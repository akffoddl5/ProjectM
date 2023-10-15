using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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

	//���� �ɼ�
	public Slider option_fx;
	public Slider option_music;

	//ü��
	public Image health_bar;
	public Text health_text;

	public PlayerControl player;




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

		//ä�� UI
		health_bar.fillAmount = (player.hp / player.hp_max);
		health_text.text = player.hp + "/" + player.hp_max;


		//�ɼ����� ���� ����
		SoundManager.instance.audios[0].volume = option_music.value;
		for (int i = 0; i < SoundManager.instance.audios.Length; i++)
		{
			if (i != 0) SoundManager.instance.audios[i].volume = option_fx.value;
		}
		//Debug.Log(player.hp + "/" + player.hp_max);
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
}
