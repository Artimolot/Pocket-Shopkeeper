using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jurist : Staff
{
	[SerializeField]
	private int[] priceContract;
	[SerializeField]
	private int[] powerJurist;

	private int selectLocation;

	public Location location;
	public Story story;

	public override void Invite(int select)
	{
		if(ScriptManager.Instance.money >= priceContract[select])
		{
			ScriptManager.Instance.money -= priceContract[select];
			ScriptManager.Instance.ActivePowerJurist += powerJurist[select];
			UI.Instance.HireAndLeaveJurist(select, true);
			Message.Instance.PrintStatistics(4, 0, ScriptManager.Instance.ActivePowerJurist, 0f);
			Audio.instance.playSound(0);
		}
		else
		{
			Message.Instance.CallMessage("Недостаточно денег");
		}
	}

	public void CaptureStore()
	{
		int select = selectLocation;
		if (ScriptManager.Instance.money >= location.priceLocation[select])
		{
			Audio.instance.playSound(1);
			ScriptManager.Instance.money -= location.priceLocation[select];
			int chance = Random.Range(0, 100);
			if(chance <= location.chanceCapture[select] + ScriptManager.Instance.ActivePowerJurist)
			{
				if (select == 2)
				{
					ScriptManager.Instance.selectMusic = 1;
				}
				if(select > 5)
				{
					ScriptManager.Instance.selectMusic = 2;
				}
				location.player.clip = location.musicClips[ScriptManager.Instance.selectMusic];
				location.player.Play();
				UI.Instance.HireAndLeaveJurist(select, false);
				ScriptManager.Instance.ActivePowerJurist = 0;
				ScriptManager.Instance.activeCapacityLocation = location.capacityLocation[select];
				ScriptManager.Instance.staticCapacityLocation = location.capacityLocation[select];
				ScriptManager.Instance.activeAssaultLocation = location.assaultLocation[select];
				UI.Instance.NewLocation(select);
				Message.Instance.PrintStatistics(0, ScriptManager.Instance.staticCapacityLocation, ScriptManager.Instance.activeAssaultLocation, 0f);
				story.StartStory(select);
			}
			else
			{
				UI.Instance.HireAndLeaveJurist(select, false);
				ScriptManager.Instance.ActivePowerJurist = 0;
				Message.Instance.CallMessage("Неудалось захватить киоск");
				DisplayChanceCapture(select);
			}
		}
		else
		{
			Message.Instance.CallMessage("Недостаточно денег");
		}
	}

	public void DisplayChanceCapture(int select)
	{
		selectLocation = select;
		int chance = location.chanceCapture[select] + ScriptManager.Instance.ActivePowerJurist;
		UI.Instance.ChanceInfoCapture(chance);
	}
}
