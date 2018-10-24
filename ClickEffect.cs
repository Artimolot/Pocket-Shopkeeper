using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickEffect : MonoBehaviour
{
	private bool move;
	private Vector2 randVector;

	private void Update()
	{
		if (!move) return;
		transform.Translate(randVector * Time.deltaTime);
	}
	public void StartMoution(Sprite image)
	{
		transform.localPosition = Vector2.zero;
		GetComponent<Image>().sprite = image;
		randVector = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
		move = true;
		GetComponent<Animation>().Play();
	}

	public void StopMoution()
	{
		move = false;
	}
}
