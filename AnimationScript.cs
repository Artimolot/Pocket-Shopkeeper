using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

	[SerializeField]
	private GameObject Wheel;

	private void Update ()
	{
		Wheel.transform.Rotate(0, 0, 1);
	}
}
