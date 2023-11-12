using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sound_Type
{
	BACKGROUND,
	NORMAL_SHOOT,
	SELECT,

}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

	public AudioSource[] audios;
	public Dictionary<Sound_Type, AudioClip> clip_dictionary = new Dictionary<Sound_Type, AudioClip>();
	public AudioClip[] clips;

	public void PlayerOneShot(Sound_Type _clip, bool _loop, int _audio_idx)
	{
		audios[_audio_idx].clip = clip_dictionary[_clip];
		audios[_audio_idx].loop = _loop;
		audios[_audio_idx].Play();
	}

	public void Pause(int _audio_idx)
	{
		audios[_audio_idx].Pause();
	}

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

		//clip_dictionary[Sound_Type.BACKGROUND] = clips[0];
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftAlt))
		{
			Cursor.visible = !Cursor.visible;

			Cursor.lockState = (CursorLockMode)((int)Cursor.lockState ^ 1);
			Debug.Log(Cursor.lockState + "  << locked state");
		}
	}
}
