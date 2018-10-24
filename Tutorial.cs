using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
	[SerializeField]
	private GameObject BlockPanel;
	[SerializeField]
	private Text TutorialText;
	[SerializeField]
	private GameObject TutorialPanel;

	private int index;

	private void Start()
	{
		if(ScriptManager.Instance.tutorial == true)
		{
			BlockPanel.SetActive(true);
			TutorialPanel.SetActive(true);
		}
		else
		{
			BlockPanel.SetActive(false);
			TutorialPanel.SetActive(false);
		}
	}

	public void TutorialGame()
	{
		switch (index)
		{
			case 0:
				index += 1;
				Message.Instance.StatisticsPanel.SetActive(true);
				TutorialText.text = "Отец: Это панель статистики. Здесь ты можешь увидеть всю информацию про киоск и его персонал.";
				UI.Instance.CloseButton.interactable = false;
				break;
			case 1:
				index += 1;
				Message.Instance.StatisticsPanel.SetActive(false);
				UI.Instance.ActiveMainPanel(0);
				TutorialText.text = "Отец: Как только у тебя появятся деньги на новый киоск, взгляни на карту. Ты можешь увидеть активный киоск, который можно захватить, но будь осторожен — всегда есть риск неудачи.";
				break;
			case 2:
				index += 1;
				UI.Instance.ActiveMainPanel(1);
				TutorialText.text = "Отец: Это панель найма персонала, а именно: продавцов, юристов, охраны, а также транспорта.  Юристы находятся в самом конце списка.";
				break;
			case 3:
				index += 1;
				UI.Instance.ActiveUpgradePanel(0);
				BlockPanel.SetActive(false);
				TutorialText.text = "Отец: На данный момент у тебя есть кое-какие деньги. Найми продавца для того, чтобы он реализовывал товар в твоё отсутствие и помогал продавать его, когда ты в киоске.";
				break;
			case 4:
				if (UI.Instance.SellerText[0].text == "Работает")
				{
					index += 1;
					UI.Instance.ActiveUpgradePanel(1);
					BlockPanel.SetActive(true);
					TutorialText.text = "Отец: Охрана поможет защитить твой киоск от грабителей. При захвате нового киоска шанс грабежа возрастает. Твой киоск могут ограбить один раз в день, при этом ты потеряешь половину своих денег.";
				}
				break;
			case 5:
				index += 1;
				UI.Instance.ActiveUpgradePanel(2);
				BlockPanel.SetActive(false);
				TutorialText.text = "Отец: Транспорт - один из основных аспектов бизнеса. Он доставляет товар в твой киоск. Имеет такие показатели: скорость доставки и вместимость товара. Арендуй мопед, на большее у тебя нет средств.";
				break;
			case 6:
				if(UI.Instance.CarText[0].text == "Арендовано")
				{
					index += 1;
					BlockPanel.SetActive(true);
					UI.Instance.ActiveUpgradePanel(3);
					TutorialText.text = "Отец: Юристы... Эти сладкоголосые дьяволы повышают шанс захвата киоска легальным путём. Перед захватом подумай дважды и трезво поразмысли, хватит ли тебе сил.";
				}
				break;
			case 7:
				index += 1;
				BlockPanel.SetActive(false);
				UI.Instance.ActiveMainPanel(2);
				TutorialText.text = "Отец: Заключи контракт с поставщиком. Благодаря соглашению с ним тебе откроются 3 вида товара его категории. Если товар у поставщика закончился, перезаключи договор."; 
				break;
			case 8:
				if(UI.Instance.ResetContractButton[0].interactable == true)
				{
					index += 1;
					BlockPanel.SetActive(true);
					UI.Instance.ActiveMainPanel(3);
					TutorialText.text = "Отец: Здесь ты можешь увидеть категории товаров. У каждой из них есть наценка — это процент, который ты заработаешь от продажи товара. Наценку можно поднимать при повышении уровня.";
				}
				break;
			case 9:
				index += 1;
				UI.Instance.ActiveProductPanel(0);
				TutorialText.text = "Отец: Как говорилось ранее, после заключения контракта откроется три вида товаров. У каждого товара есть цена и его ограниченное количество.";
				break;
			case 10:
				index += 1;
				UI.Instance.ActiveMainPanel(5);
				TutorialText.text = "Отец: Вроде бы всё сказал. Сейчас твоя задача — заказать товар. Нажимай на киоск для того, чтобы продавать товар. Чем больше ты торгуешь, тем больше твой уровень.";
				break;
			case 11:
				index += 1;
				TutorialText.text = "Отец: Ладно, пойду я. Не повторяй моих ошибок. Хотя я даже не знаю, что я такого сделал, что мой киоск снесли... Удачи, сынок.";
				break;
			default:
				BlockPanel.SetActive(false);
				TutorialPanel.SetActive(false);
				ScriptManager.Instance.tutorial = false;
				UI.Instance.CloseButton.interactable = true;
				break;
		}
	}
}
