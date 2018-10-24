using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Staff
{
	[SerializeField]
	private float[] payDay;
	[SerializeField]
	private float[] speedDelivery;
	[SerializeField]
	private int[] capacity;

	private void Awake()
	{
		
	}

	public override void Invite(int select)
	{
		if (ScriptManager.Instance.TimeDeliverCar <= 0f)
		{
			if (ScriptManager.Instance.money >= payDay[select] && ScriptManager.Instance.PayDayCar != payDay[select])
			{
				ScriptManager.Instance.money -= payDay[select];
				ScriptManager.Instance.PayDayStaff -= ScriptManager.Instance.PayDayCar;
				ScriptManager.Instance.PayDayStaff += payDay[select];
				ScriptManager.Instance.PayDayCar = payDay[select];
				ScriptManager.Instance.SpeedDeliveryCar = speedDelivery[select];
				ScriptManager.Instance.CapacityCar = capacity[select];
				UI.Instance.SetMaxCountSlider(capacity[select]);
				UI.Instance.LeaseCar(select);
				Message.Instance.PrintStatistics(5, 0, 0, ScriptManager.Instance.PayDayStaff);
				Message.Instance.PrintStatistics(1, ScriptManager.Instance.CapacityCar, 0, ScriptManager.Instance.SpeedDeliveryCar);
				Audio.instance.playSound(0);
			}
			else
			{
				Message.Instance.CallMessage("Недостаточно денег или машина уже арендована");
			}
		}
		else
		{
			Message.Instance.CallMessage("Доджитесь пока машина вернётся c доставки");
		}
	}
}
