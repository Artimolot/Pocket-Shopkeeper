using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPGSystem : MonoBehaviour
{ 
	[SerializeField]
	private GameObject UpLevelPanel;
	[SerializeField]
	private Text[] InfoUpLevelText;

	[SerializeField]
	private int[] levelNextPoint;
	[SerializeField]
	private GameObject Block;
	[SerializeField]
	private Animation anim;

	#region Markup
	[SerializeField]
	private Text[] markupText;
	[SerializeField]
	private GameObject MarkupPanel;
	private bool activeMarkupPanel = false;
	#endregion

	private void Update()
	{
		Message.Instance.PrintStatistics(6, 0, levelNextPoint[ScriptManager.Instance.Level - 1] - ScriptManager.Instance.Point, 0);
		if(ScriptManager.Instance.Point >= levelNextPoint[ScriptManager.Instance.Level - 1])
		{
			UpLevel();
		}
	}

	public void UpLevel()
	{
		anim.Play();
		Block.SetActive(true);
		Audio.instance.playSound(5);
		ScriptManager.Instance.Level += 1;
		InfoUpLevelText[1].text = "" + ScriptManager.Instance.bonusMoney + "$";
		if (ScriptManager.Instance.Level % 5 == 0)
		{
			activeMarkupPanel = true;
			InfoUpLevelText[2].text = "+ наценка на товар";
			markupText[0].text = "" + ScriptManager.Instance.MarkupBackery + "/60% + 5%";
			markupText[1].text = "" + ScriptManager.Instance.MarkupSnacks + "/65% + 5%";
			markupText[2].text = "" + ScriptManager.Instance.MarkupBeverages + "/70% + 5%";
			markupText[3].text = "" + ScriptManager.Instance.MarkupCigarettes + "/75% + 5%";
			markupText[4].text = "" + ScriptManager.Instance.MarkupAlcohol + "/80% + 5%";
			if (ScriptManager.Instance.MarkupBackery >= 60)
			{
				UI.Instance.MarkupProductButton[0].interactable = false;
			}
			if(ScriptManager.Instance.MarkupSnacks >= 65)
			{
				UI.Instance.MarkupProductButton[1].interactable = false;
			}
			if(ScriptManager.Instance.MarkupBeverages >= 70)
			{
				UI.Instance.MarkupProductButton[2].interactable = false;
			}
			if(ScriptManager.Instance.MarkupCigarettes >= 75)
			{
				UI.Instance.MarkupProductButton[3].interactable = false;
			}
			if (ScriptManager.Instance.MarkupAlcohol >= 80)
			{
				UI.Instance.MarkupProductButton[4].interactable = false;
			}
		}
		else
		{
			InfoUpLevelText[2].text = "";
		}
		if (ScriptManager.Instance.Level == 12 || ScriptManager.Instance.Level == 36)
		{
			for(int i = 0; i < UI.Instance.SecurityButton.Length; i++)
			{
				if(UI.Instance.SecurityText[i].text == "Заблокировано")
				{
					UI.Instance.SecurityButton[i].interactable = true;
					UI.Instance.SecurityText[i].text = "Нанять";
					i++;
					InfoUpLevelText[3].text = "Открыто:\nОхрана " + i + "ур.";
					break;
				}
			}
		}
		else
		{
			InfoUpLevelText[3].text = "";
		}
		if (ScriptManager.Instance.Level == 24 || ScriptManager.Instance.Level == 45 || ScriptManager.Instance.Level == 57)
		{
			for(int i = 0; i < UI.Instance.JuristButton.Length; i++)
			{
				if(UI.Instance.JuristText[i].text == "Заблокировано")
				{
					UI.Instance.JuristButton[i].interactable = true;
					UI.Instance.JuristText[i].text = "Нанять";
					i++;
					InfoUpLevelText[3].text = "Открыто:\nЮрист " + i + "ур.";
					break;
				}
			}
		}
		else
		{
			InfoUpLevelText[3].text = "";
		}
		if (ScriptManager.Instance.Level == 21 || ScriptManager.Instance.Level == 30 || ScriptManager.Instance.Level == 48 || ScriptManager.Instance.Level == 63)
		{
			for (int i = 0; i < UI.Instance.ProviderButton.Length; i++)
			{
				if (UI.Instance.ProviderText[i].text == "Заблокировано")
				{
					UI.Instance.ProviderButton[i].interactable = true;
					UI.Instance.ProviderText[i].text = "Заключить";
					i++;
					InfoUpLevelText[3].text = "Открыто:\nПоставщик " + i + "ур.";
					break;
				}
			}
		}
		else
		{
			InfoUpLevelText[3].text = "";
		}
		if (ScriptManager.Instance.Level == 6 || ScriptManager.Instance.Level == 18 || ScriptManager.Instance.Level == 39 || ScriptManager.Instance.Level == 51 || ScriptManager.Instance.Level == 60)
		{
			for (int i = 0; i < UI.Instance.CarButton.Length; i++)
			{
				if (UI.Instance.CarText[i].text == "Заблокировано")
				{
					UI.Instance.CarButton[i].interactable = true;
					UI.Instance.CarText[i].text = "Арендовать";
					i++;
					InfoUpLevelText[3].text = "Открыто:\nТранспорт " + i + "ур.";
					break;
				}
			}
		}
		else
		{
			InfoUpLevelText[3].text = "";
		}
		if (ScriptManager.Instance.Level == 3 || ScriptManager.Instance.Level == 9 || ScriptManager.Instance.Level == 15 || ScriptManager.Instance.Level == 27 || ScriptManager.Instance.Level == 33 || ScriptManager.Instance.Level == 42 || ScriptManager.Instance.Level == 54 || ScriptManager.Instance.Level == 66)
		{
			for (int i = 0; i < UI.Instance.SellerBttn.Length; i++)
			{
				if (UI.Instance.SellerText[i].text == "Заблокировано")
				{
					UI.Instance.SellerBttn[i].interactable = true;
					UI.Instance.SellerText[i].text = "Нанять";
					i++;
					InfoUpLevelText[3].text = "Открыто:\nПродавец " + i + "ур.";
					break;
				}
			}
		}
		else
		{
			InfoUpLevelText[3].text = "";
		}
		ScriptManager.Instance.money += ScriptManager.Instance.bonusMoney;
		ScriptManager.Instance.bonusMoney += 50;
		UI.Instance.LevelText.text = "Level: " + ScriptManager.Instance.Level;
		Message.Instance.PrintStatistics(6, 0, levelNextPoint[ScriptManager.Instance.Level - 1], 0);
		InfoUpLevelText[0].text = "Level: " + ScriptManager.Instance.Level;
		ScriptManager.Instance.Point = 0;
		UpLevelPanel.SetActive(true);
	}

	public void CloseUpLevelPanel()
	{
		Block.SetActive(false);
		if (activeMarkupPanel)
		{
			MarkupPanel.SetActive(true);
			activeMarkupPanel = false;
		}
		else
		{
			MarkupPanel.SetActive(false);
			UpLevelPanel.SetActive(false);
		}
	}

	public void MarkupUp(int select)
	{
		switch (select)
		{
			case 0:
				ScriptManager.Instance.MarkupBackery += 5;
				UI.Instance.MarkupProductText[select].text = "Выпечка\nНаценка: " + ScriptManager.Instance.MarkupBackery + "%";
				break;
			case 1:
				ScriptManager.Instance.MarkupSnacks += 5;
				UI.Instance.MarkupProductText[select].text = "Закуски\nНаценка: " + ScriptManager.Instance.MarkupSnacks + "%";
				break;
			case 2:
				ScriptManager.Instance.MarkupBeverages += 5;
				UI.Instance.MarkupProductText[select].text = "Напитки\nНаценка: " + ScriptManager.Instance.MarkupBeverages + "%";
				break;
			case 3:
				ScriptManager.Instance.MarkupCigarettes += 5;
				UI.Instance.MarkupProductText[select].text = "Сигареты\nНаценка: " + ScriptManager.Instance.MarkupCigarettes + "%";
				break;
			default:
				ScriptManager.Instance.MarkupAlcohol += 5;
				UI.Instance.MarkupProductText[select].text = "Алкоголь\nНаценка: " + ScriptManager.Instance.MarkupAlcohol + "%";
				break;
		}
		activeMarkupPanel = false;
		CloseUpLevelPanel();
	}
}
