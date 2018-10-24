using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
	public static Message Instance;

	#region InfoPanel
	public GameObject StatisticsPanel;
	public Text[] TimeContactProductText;
	public Text[] StatisticsText;
	#endregion

	[SerializeField]
	private GameObject MessagePanel;
	[SerializeField]
	private Text textMessageText;

	private void Awake()
	{
		Instance = this;
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	public void CallMessage(string message)
	{
		MessagePanel.SetActive(true);
		textMessageText.text = message;
	}

	public void PayDayAndAttackToKiosk(bool attack)
	{
		MessagePanel.SetActive(true);
		if (attack)
		{
			textMessageText.text = "Вы выдали зарплату\n" + "Вас ограбили вы потеряли: " + ScriptManager.Instance.money + "$";
		}
		else
		{

			textMessageText.text = "Вы выдали зарплату\n" + "Вы смогли предотвратить ограбления кисока";
		}
	}

	public void CloseMessagePanel()
	{
		MessagePanel.SetActive(false);
	}

	public void ActiveStatisticsPanel()
	{
		StatisticsPanel.SetActive(!StatisticsPanel.activeSelf);
	}

	public void PrintStatistics(int select, int capacity, int chance, float time)
	{
		switch (select)
		{
			case 0:
				StatisticsText[select].text = "Киоск\nВместимость: " + capacity + "т.\nШанс ограбления: " + chance + "%"; 
				break;
			case 1:
				StatisticsText[select].text = "Транспорт\nВместимость: " + capacity + "т.\nСкорость доставки:\n" + time + "сек.";
				break;
			case 2:
				StatisticsText[select].text = "Продавец\nСкорость продажи:\n" + time + "сек.\nБонус к клику: " + chance; 
				break;
			case 3:
				StatisticsText[select].text = "Охрана\nШанс защиты киоска: " + chance + "%";
				break;
			case 4:
				StatisticsText[select].text = "Юристы\nШанс захвата киоска: +" + chance + "%";
				break;
			case 5:
				StatisticsText[select].text = "Зарплата сотрудников в день:\n" + (int)time + "$";
				break;
			case 6:
				StatisticsText[select].text = "Опыта до следущего уровня:\n" + chance;
				break;
			case 7:
				StatisticsText[select].text = "Всего продано товара:\n" + capacity;
				break;
			default:
				StatisticsText[select].text = "Заработано в день:\n" + chance;
				break;
		}
	}

	public void PrintTimeContract(int select, int hour, int minute)
	{
		switch(select)
		{
			case 0:
				TimeContactProductText[select].text = "Выпечка: " + hour + ":" + minute;
				break;
			case 1:
				TimeContactProductText[select].text = "Закуски: " + hour + ":" + minute;
				break;
			case 2:
				TimeContactProductText[select].text = "Напитки: " + hour + ":" + minute;
				break;
			case 3:
				TimeContactProductText[select].text = "Сигареты: " + hour + ":" + minute;
				break;
			default:
				TimeContactProductText[select].text = "Алкоголь: " + hour + ":" + minute;
				break;
		}
		
	}
}
