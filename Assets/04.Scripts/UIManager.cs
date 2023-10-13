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
	
	
	private void Update()
	{
		option_left_graph.fillAmount = option_left_slider.value / 2;
		option_right_graph.fillAmount = option_right_slider.value / 2;

		option_left_text.text = string.Format("{0:N2}", option_left_slider.value);
		option_right_text.text = string.Format("{0:N2}", option_right_slider.value);
	}

	public void OptionClose()
	{
		canvas_option.SetActive(false);
	}
}
