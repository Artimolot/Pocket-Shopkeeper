using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;

public class AdView : MonoBehaviour
{
	public bool kek;

	private void Start()
	{
		string appKey = "539a028182fd0c36038a493fe2b364086bdbc1758b6453db";
		Appodeal.disableLocationPermissionCheck();
		Appodeal.disableNetwork("inmobi", Appodeal.BANNER | Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
		Appodeal.initialize(appKey, Appodeal.REWARDED_VIDEO | Appodeal.INTERSTITIAL);
	}

	public void ViewVideoDelivery()
	{
		Appodeal.show(Appodeal.INTERSTITIAL);
		if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
		{
			BoostDelivery();
		}
	}

	public void ViewVideoContract(bool YesNo)
	{
		if (YesNo)
		{
			Appodeal.show(Appodeal.REWARDED_VIDEO);
			if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
			{
				ResetContracts();
			}
		}
		else
		{
			UI.Instance.PanelResetContract.SetActive(false);
		}
	}

	public void BoostDelivery()
	{
		ScriptManager.Instance.TimeDeliverCar = 1.0f;
		UI.Instance.BoostDelivery.interactable = false;
	}

	public void ResetContracts()
	{
		int select = ScriptManager.Instance.selectContact;
		ScriptManager.Instance.timeContractProvider[select] = 1.5f;
		UI.Instance.ResetContractButton[select].interactable = false;
		UI.Instance.PanelResetContract.SetActive(false);
	}
}
