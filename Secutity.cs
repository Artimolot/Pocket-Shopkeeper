using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secutity : Staff
{
	[SerializeField]
	private float[] payDay;
	[SerializeField]
	private int[] defencedPower;

	public override void Invite(int select)
	{
		if (ScriptManager.Instance.money >= payDay[select] && ScriptManager.Instance.ActivePayDaySecurity != payDay[select]) 
		{
			ScriptManager.Instance.money -= payDay[select];
			ScriptManager.Instance.PayDayStaff -= ScriptManager.Instance.ActivePayDaySecurity;
			ScriptManager.Instance.PayDayStaff += payDay[select];
			ScriptManager.Instance.ActivePayDaySecurity = payDay[select];
			ScriptManager.Instance.ActiveDefenced += defencedPower[select];
			UI.Instance.HireAndLeaveSecurity(select, true);
			Message.Instance.PrintStatistics(5, 0, 0, ScriptManager.Instance.PayDayStaff);
			Message.Instance.PrintStatistics(3, 0, ScriptManager.Instance.ActiveDefenced, 0f);
			Audio.instance.playSound(0);
		}
		else
		{
			Message.Instance.CallMessage("Недостаточно денег или охранник уже нанят");
		}
	}
}
