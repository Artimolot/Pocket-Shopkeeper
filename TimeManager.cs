using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
	public static TimeManager Instance;

	private Message message;
	private UI ui;

	private void Awake()
	{
		message = GameObject.Find("MessageController").GetComponent<Message>();
		ui = GameObject.Find("UIController").GetComponent<UI>();
		Instance = this;
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	public void ResumptionCoroutine(int select , int index)
	{
		switch (select)
		{
			case 0:
				StartCoroutine(DeliveryProduct());
				break;
			case 1:
				StartCoroutine(PayDay());
				break;
			case 2:
				StartCoroutine(AutoSale());
				break;
			case 3:
				StartCoroutine(ContractTime(index));
				break;
		}
	}

	public void DeliveryProduct(int product, float receipts)
	{
		ui.BoostDelivery.interactable = true;
		ScriptManager.Instance.TimeDeliverCar = ScriptManager.Instance.SpeedDeliveryCar;
		ScriptManager.Instance.DeliveryProductInCar += product;
		ScriptManager.Instance.ReceiptsProductInCar += receipts;
		Audio.instance.playSound(2);
		ResumptionCoroutine(0, 0);
	}


	IEnumerator DeliveryProduct()
	{
		int minute, second;
		while(ScriptManager.Instance.TimeDeliverCar >= 0f)
		{
			ScriptManager.Instance.TimeDeliverCar -= 1.0f * Time.deltaTime;
			if((int)ScriptManager.Instance.TimeDeliverCar > 60)
			{
				minute = (int)ScriptManager.Instance.TimeDeliverCar / 60;
			}
			else
			{
				minute = 0;
			}
			second = (int)ScriptManager.Instance.TimeDeliverCar - (minute * 60);
			ui.DisplayDeliveryProduct(minute, second);
			yield return null;
		}
		ui.BoostDelivery.interactable = false;
		ScriptManager.Instance.TimeDeliverCar = -0.1f;
		ScriptManager.Instance.SaleProductInNextLevel += ScriptManager.Instance.DeliveryProductInCar;
		ScriptManager.Instance.CountProductInSale += ScriptManager.Instance.DeliveryProductInCar;
		ScriptManager.Instance.ProfitProduct += ScriptManager.Instance.ReceiptsProductInCar;
		ScriptManager.Instance.DeliveryProductInCar = 0;
		ScriptManager.Instance.ReceiptsProductInCar = 0;
		ScriptManager.Instance.CheckProductInStore = true;
		ResumptionCoroutine(2, 0);
	}

	IEnumerator PayDay()
	{
		while (true)
		{
			ScriptManager.Instance.TimePayDay += 1.0f * Time.deltaTime;
			if(ScriptManager.Instance.TimePayDay >= 86400f)
			{
				ScriptManager.Instance.TimePayDay = 0f;
				ScriptManager.Instance.money -= ScriptManager.Instance.PayDayStaff;
				ScriptManager.Instance.EarnedMoneyDay = 0;
				Message.Instance.PayDayAndAttackToKiosk(AttackToKiosk());
				Message.Instance.PrintStatistics(8, 0, (int)ScriptManager.Instance.EarnedMoneyDay, 0);
			}
			yield return null;
		}
	}

	IEnumerator AutoSale()
	{
		float time = 30f;
		while(time > 0f)
		{
			time -= 1.0f * Time.deltaTime;
			if(ScriptManager.Instance.CountProductInSale > 0 && time < 0f)
			{
				ScriptManager.Instance.CountProductInSale -= ScriptManager.Instance.ActiveSaleSeller;
				ScriptManager.Instance.activeCapacityLocation += ScriptManager.Instance.ActiveSaleSeller;
				time = 30f;
			}
			yield return null;
		}
	}

	IEnumerator ContractTime(int index)
	{
		int hour, minute;
		while(ScriptManager.Instance.timeContractProvider[index] > 0f)
		{
			ScriptManager.Instance.timeContractProvider[index] -= 1.0f * Time.deltaTime;
			if((int)ScriptManager.Instance.timeContractProvider[index] > 3600)
			{
				hour = (int)ScriptManager.Instance.timeContractProvider[index] / 3600;
			}
			else
			{
				hour = 0;
			}
			minute = ((int)ScriptManager.Instance.timeContractProvider[index] - (hour * 3600)) / 60;
			message.PrintTimeContract(index, hour, minute);
			yield return null;
		}
		ui.ResetContractButton[index].interactable = false;
		ScriptManager.Instance.timeContractProvider[index] = -1f;
		ui.UpdateContract(index);
	}

	// Пиздец, это костыль.
	public bool AttackToKiosk()
	{
		int chance = Random.Range(0, 100);
		if (chance > ScriptManager.Instance.activeAssaultLocation + ScriptManager.Instance.ActiveDefenced)
		{
			ScriptManager.Instance.money = ScriptManager.Instance.money / 2;
			UI.Instance.HireAndLeaveSecurity(0, false);
			ScriptManager.Instance.ActiveDefenced = 0;
			return true;
		}
		return false;
	}
}
