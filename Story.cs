using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
	#region Text
	[SerializeField]
	private string[] kiosk1;
	[SerializeField]
	private string[] kiosk2;
	[SerializeField]
	private string[] kiosk3;
	[SerializeField]
	private string[] kiosk4;
	[SerializeField]
	private string[] kiosk5;
	[SerializeField]
	private string[] kiosk6;
	[SerializeField]
	private string[] kiosk7;
	[SerializeField]
	private string[] kiosk8;
	#endregion

	[SerializeField]
	private GameObject StoryPanel;
	[SerializeField]
	private Text StoryText;
	[SerializeField]
	private GameObject BlockPanel;
	[SerializeField]
	private Sprite[] DialogImg;
	[SerializeField]
	private GameObject DialogPanel;

	private int indexStory;
	private int positionMassiv = 0;

	private void ViewTextStory(int select)
	{
		switch (select)
		{
			case 0:
				if (positionMassiv < kiosk1.Length)
				{
					StoryText.text = kiosk1[positionMassiv];
				}
				else
				{
					BlockPanel.SetActive(false);
					StoryPanel.SetActive(false);
				}
				break;
			case 1:
				if (positionMassiv < kiosk2.Length)
				{
					StoryText.text = kiosk2[positionMassiv];
				}
				else
				{
					BlockPanel.SetActive(false);
					StoryPanel.SetActive(false);
				}
				break;
			case 2:
				if (positionMassiv < kiosk3.Length)
				{
					StoryText.text = kiosk3[positionMassiv];
				}
				else
				{
					BlockPanel.SetActive(false);
					StoryPanel.SetActive(false);
				}
				break;
			case 3:
				if (positionMassiv < kiosk4.Length)
				{
					StoryText.text = kiosk4[positionMassiv];
				}
				else
				{
					BlockPanel.SetActive(false);
					StoryPanel.SetActive(false);
				}
				break;
			case 4:
				if (positionMassiv < kiosk5.Length)
				{
					StoryText.text = kiosk5[positionMassiv];
				}
				else
				{
					BlockPanel.SetActive(false);
					StoryPanel.SetActive(false);
				}
				break;
			case 5:
				if (positionMassiv < kiosk6.Length)
				{
					StoryText.text = kiosk6[positionMassiv];
				}
				else
				{
					BlockPanel.SetActive(false);
					StoryPanel.SetActive(false);
				}
				break;
			case 6:
				if (positionMassiv < kiosk7.Length)
				{
					StoryText.text = kiosk7[positionMassiv];
				}
				else
				{
					BlockPanel.SetActive(false);
					StoryPanel.SetActive(false);
				}
				break;
			default:
				if (positionMassiv < kiosk8.Length)
				{
					StoryText.text = kiosk8[positionMassiv];
				}
				else
				{
					BlockPanel.SetActive(false);
					StoryPanel.SetActive(false);
				}
				break;
		}
	}

	public void StartStory(int index)
	{
		indexStory = index;
		StoryPanel.SetActive(true);
		BlockPanel.SetActive(true);
		positionMassiv = 0;
		DialogPanel.GetComponent<Image>().sprite = DialogImg[index];
		ViewTextStory(indexStory);
	}

	public void NextPositionMassiv()
	{
		positionMassiv++;
		ViewTextStory(indexStory);
	}
}
