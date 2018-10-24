using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
	public AudioClip[] musicClips;
	public AudioSource player;

	private void Start()
	{
		player.clip = musicClips[ScriptManager.Instance.selectMusic];
		player.Play();
	}

	public float[] priceLocation;
	public int[] capacityLocation;
	public int[] chanceCapture;
	public int[] assaultLocation;
}
