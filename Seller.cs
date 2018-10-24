using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : Staff
{
	[SerializeField]
	private int[] baffClick;
	[SerializeField]
	private float[] payDay;
	[SerializeField]
	private int[] AutoClick;

	public override void Invite(int select)
	{
		if (ScriptManager.Instance.money >= payDay[select] && ScriptManager.Instance.ActivePayDaySeller != payDay[select]) 
		{
			ScriptManager.Instance.money -= payDay[select];
			ScriptManager.Instance.PayDayStaff -= ScriptManager.Instance.ActivePayDaySeller;
			ScriptManager.Instance.PayDayStaff += payDay[select];
			ScriptManager.Instance.ActivePayDaySeller = payDay[select];
			ScriptManager.Instance.click = baffClick[select];
			ScriptManager.Instance.ActiveSaleSeller = AutoClick[select];
			UI.Instance.HireSeller(select);
			Message.Instance.PrintStatistics(5, 0, 0, ScriptManager.Instance.PayDayStaff);
			Message.Instance.PrintStatistics(2, 0, baffClick[select], ScriptManager.Instance.ActiveSaleSeller);
			Audio.instance.playSound(0);
			TimeManager.Instance.ResumptionCoroutine(1, 0);
		}
		else
		{
			Message.Instance.CallMessage("Недостаточно денег или рабонтик уже нанят");
		}
	}
}
