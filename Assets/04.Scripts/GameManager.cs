using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

	public float player_att;
	public float player_hp;

	public float current_time;
	public int current_round;
	public float round_time = 30;

	public int current_item_num = 0;
	public HashSet<ITEM> current_item = new HashSet<ITEM>();



	//Ÿ�Ӷ���
	public PlayableDirector stage_show;
	
	

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		SpawnManager.instance.Spawn(1);

	}

	private void Update()
	{
		if (UIManager.instance != null)
		{
			current_time += Time.deltaTime;
			if (current_time > round_time)
			{
				current_time = 0;
				current_round++;
				//stage Ÿ�Ӷ��� ����
				UIManager.instance.level_text.text = current_round.ToString();
				UIManager.instance.round_text.text = "STAGE " + current_round.ToString();
				stage_show.Play();



				//���� 38�� ��ȯ���̶� �Բ� ���� (��ũ���ͺ������Ʈ�� �ұ ���)
				
				SpawnManager.instance.Spawn(1);
				
			}


			UIManager.instance.level_bar.fillAmount = current_time / round_time;
			//current_time �� ���� ������ ����
			//
		}

	}

}
