using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

	public AudioClip[] audioClips;

	public static Audio instance;

	public AudioSource player;

	private void Awake()
	{
		if (instance == null) instance = this;
	}

	public void playSound(int index)
	{
		player.clip = audioClips[index];
		player.Play();
	}
}
