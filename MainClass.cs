using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainClass : MonoBehaviour
{
	public int countClick;

	private void Start()
	{
		for(int i = 0; i < UI.Instance.clickImagePool.Length; i++)
		{
			UI.Instance.clickImagePool[i] = Instantiate(UI.Instance.clickPrefab, UI.Instance.cliclParent.transform).GetComponent<ClickEffect>();
		}
	}

	private void Update()
	{
		if (ScriptManager.Instance.CountProductInSale > 1)
		{
			UI.Instance.DisplayProductInStore(ScriptManager.Instance.CountProductInSale);
		}
		else
		{
			ScriptManager.Instance.CountProductInSale = 0;
			CheckSalleProduct();
			UI.Instance.DisplayProductInStore(0);
		}
		UI.Instance.DisplayMoney(ScriptManager.Instance.money);
	}

	public void OnClick()
	{
		if(ScriptManager.Instance.CountProductInSale > 11)
		{
			ScriptManager.Instance.CountProductInSale -= ScriptManager.Instance.click;
			ScriptManager.Instance.activeCapacityLocation += ScriptManager.Instance.click;
			UI.Instance.clickImagePool[countClick].StartMoution(UI.Instance.clickImage[UnityEngine.Random.Range(0, 45)]);
			countClick = countClick == UI.Instance.clickImagePool.Length - 1 ? 0 : countClick + 1;
		}
		else if(ScriptManager.Instance.CountProductInSale <= 11 && ScriptManager.Instance.CountProductInSale > 1)
		{
			ScriptManager.Instance.CountProductInSale -= 1;
			ScriptManager.Instance.activeCapacityLocation += 1;
			UI.Instance.clickImagePool[countClick].StartMoution(UI.Instance.clickImage[UnityEngine.Random.Range(0, 45)]);
			countClick = countClick == UI.Instance.clickImagePool.Length - 1 ? 0 : countClick + 1;
		}
	}

	private void CheckSalleProduct()
	{
		if (ScriptManager.Instance.CountProductInSale <= 1 && ScriptManager.Instance.CheckProductInStore == true)
		{
			Audio.instance.playSound(3);
			ScriptManager.Instance.money += ScriptManager.Instance.ProfitProduct;
			ScriptManager.Instance.EarnedMoneyDay += ScriptManager.Instance.TempEarndeMoneyDay;
			ScriptManager.Instance.ProfitProduct = 0;
			ScriptManager.Instance.TempEarndeMoneyDay = 0;
			ScriptManager.Instance.activeCapacityLocation = ScriptManager.Instance.staticCapacityLocation;
			ScriptManager.Instance.AllSaleProduct += ScriptManager.Instance.SaleProductInNextLevel;
			Message.Instance.PrintStatistics(7, ScriptManager.Instance.AllSaleProduct, 0, 0f);
			Message.Instance.PrintStatistics(8, 0, (int)ScriptManager.Instance.EarnedMoneyDay, 0);
			ScriptManager.Instance.Point += ScriptManager.Instance.SaleProductInNextLevel;
			ScriptManager.Instance.SaleProductInNextLevel = 0;
			ScriptManager.Instance.CountProductInSale = 0;
			ScriptManager.Instance.CheckProductInStore = false;
		}
	}
}
