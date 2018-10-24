using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptManager : MonoBehaviour
{
	public static ScriptManager Instance;

	private UI ui;
	private TimeManager timeManager;
	private Audio audio;
	private Message message;
	private Save save = new Save();

	private int[] timeExit = new int[6];
	private DateTime pauseTime;

	#region VariableForClasses

	#region Car
	public float PayDayCar { get; set; }
	public float SpeedDeliveryCar { get; set; }
	public int CapacityCar { get; set; }
	public int DeliveryProductInCar { get; set; }
	public float ReceiptsProductInCar { get; set; }
	public float TimeDeliverCar { get; set; }
	#endregion

	#region Jurist
	public int ActivePowerJurist { get; set; }
	#endregion

	#region Location
	public int activeCapacityLocation = 300;
	public int staticCapacityLocation = 300;
	public int activeAssaultLocation = 90;
	public int ActiveBackground = 0;
	#endregion

	#region MainClick
	public float money = 100000;
	public int click = 1;
	public float PayDayStaff;
	public int AllSaleProduct;
	public float EarnedMoneyDay; // Заработано денег в день
	public float TempEarndeMoneyDay; // Временная переменная для хранения значения во время доставки и продажи товара
	public int SaleProductInNextLevel;
	public bool CheckProductInStore;
	public float ProfitProduct { get; set; }
	public int CountProductInSale { get; set; }
	public float TimePayDay;
	public int selectMusic;
	#endregion

	#region Product
	public int MarkupBackery;
	public int MarkupSnacks;
	public int MarkupBeverages;
	public int MarkupCigarettes;
	public int MarkupAlcohol;
	public int[] activeBackeryStorage = new int[7];
	public int[] activeSnacksStorage = new int[14];
	public int[] activeBeveragesStorage = new int[6];
	public int[] activeCigarettesStorage = new int[5];
	public int[] activeAlcoholStorage = new int[15];
	#endregion

	#region Provider
	public float[] timeContractProvider;
	public int selectContact; 
	#endregion

	#region RPGSystem
	public float bonusMoney = 50;
	public int Level = 1;
	public int Point { get; set; }
	#endregion

	#region Security
	public float ActivePayDaySecurity { get; set; }
	public int ActiveDefenced { get; set; }
	public bool attack;
	#endregion

	#region Seller
	public float ActivePayDaySeller { get; set; }
	public int ActiveSaleSeller { get; set; }
	#endregion

	#region Tutorial
	public bool tutorial = true;
	#endregion

	#endregion

	private void Awake()
	{
		Instance = this;
		LoadClassInstance();
		LoadSave();
		ContinueGame();
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	private void LoadClassInstance()
	{
		ui = GameObject.Find("UIController").GetComponent<UI>();
		audio = GameObject.Find("AudioController").GetComponent<Audio>();
		message = GameObject.Find("MessageController").GetComponent<Message>();
		timeManager = GetComponent<TimeManager>();
	}

	private void LoadSave()
	{
		if (PlayerPrefs.HasKey("SaveGame"))
		{
			save = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SaveGame"));
			#region UI
			for (int i = 0; i < ui.AlcoholButton.Length; i++)
			{
				if (i < ui.SecurityButton.Length)
				{
					ui.SecurityButton[i].interactable = save.SecurityButton[i];
					ui.SecurityText[i].text = save.SecurityText[i];
				}
				if (i < ui.JuristButton.Length)
				{
					ui.JuristButton[i].interactable = save.JuristButton[i];
					ui.JuristText[i].text = save.JuristText[i];
				}
				if (i < ui.ProviderButton.Length)
				{
					ui.ProviderButton[i].interactable = save.ProvierButton[i];
					ui.ResetContractButton[i].interactable = save.ResetContract[i];
					ui.ProviderText[i].text = save.ProviderText[i];
					ui.MarkupProductText[i].text = save.MarkupProductText[i];
					ui.CigarettesButton[i].interactable = save.CigarettesButton[i];
				}
				if (i < ui.CarButton.Length)
				{
					ui.CarButton[i].interactable = save.CarButton[i];
					ui.BeveragesButton[i].interactable = save.BeveragesButton[i];
					ui.CarText[i].text = save.CarText[i];
				}
				if (i < ui.BackeryButton.Length)
				{
					ui.BackeryButton[i].interactable = save.BackeryButton[i];
				}
				if (i < ui.StoreButton.Length)
				{
					ui.StoreButton[i].interactable = save.StoreButton[i];
				}
				if (i < ui.SellerBttn.Length)
				{
					ui.SellerBttn[i].interactable = save.SellerButton[i];
					ui.SellerText[i].text = save.SellerHireText[i];
				}
				if (i < ui.SnacksButton.Length)
				{
					ui.SnacksButton[i].interactable = save.SnacksButton[i];
				}
				ui.AlcoholButton[i].interactable = save.AlcoholButton[i];
			}
			ui.BoostDelivery.interactable = save.BoostDelivery;
			#endregion

			#region VariableForClasses

			#region Car
			PayDayCar = save.PayDayCar;
			SpeedDeliveryCar = save.SpeedDeliveryCar;
			CapacityCar = save.CapacityCar;
			DeliveryProductInCar = save.DeliveryProductInCar;
			ReceiptsProductInCar = save.ReceiptsProductInCar;
			TimeDeliverCar = save.TimeDeliverCar;
			#endregion

			#region Jurist
			ActivePowerJurist = save.ActivePowerJurist;
			#endregion

			#region Location
			activeCapacityLocation = save.activeCapacityLocation;
			staticCapacityLocation = save.staticCapacityLocation;
			activeAssaultLocation = save.activeAssaultLocation;
			ActiveBackground = save.ActiveBackground;
			#endregion

			#region MainClick
			money = save.money;
			click = save.click;
			PayDayStaff = save.PayDayStaff;
			AllSaleProduct = save.AllSaleProduct;
			EarnedMoneyDay = save.EarnedMoneyDay;
			TempEarndeMoneyDay = save.TempEarndeMoneyDay;
			SaleProductInNextLevel = save.SaleProductInNextLevel;
			CheckProductInStore = save.CheckProductInStore;
			ProfitProduct = save.ProfitProduct;
			CountProductInSale = save.CountProductInSale;
			TimePayDay = save.TimePayDay;
			selectMusic = save.selectMusic;
			#endregion

			#region Message
			for (int i = 0; i < save.StatisticsText.Length; i++)
			{
				if (i < save.TimeContractProductText.Length)
				{
					message.TimeContactProductText[i].text = save.TimeContractProductText[i];
				}
				message.StatisticsText[i].text = save.StatisticsText[i];
			}
			#endregion

			#region Product
			MarkupBackery = save.MarkupBackery;
			MarkupSnacks = save.MarkupSnacks;
			MarkupBeverages = save.MarkupBeverages;
			MarkupCigarettes = save.MarkupCigarettes;
			MarkupAlcohol = save.MarkupAlcohol;
			for (int i = 0; i < activeAlcoholStorage.Length; i++)
			{
				if (i < activeCigarettesStorage.Length)
				{
					activeCigarettesStorage[i] = save.activeCigarettesStorage[i];
				}
				if (i < activeBeveragesStorage.Length)
				{
					activeBeveragesStorage[i] = save.activeBeveragesStorage[i];
				}
				if (i < activeBackeryStorage.Length)
				{
					activeBackeryStorage[i] = save.activeBackeryStorage[i];
				}
				if (i < activeSnacksStorage.Length)
				{
					activeSnacksStorage[i] = save.activeSnacksStorage[i];
				}
				activeAlcoholStorage[i] = save.activeAlcoholStorage[i];
			}
			#endregion

			#region Provider
			for (int i = 0; i < timeContractProvider.Length; i++)
			{
				timeContractProvider[i] = save.timeContractProvider[i];
			}
			#endregion

			#region RPGSystem
			bonusMoney = save.bonusMoney;
			Level = save.Level;
			Point = save.Point;
			ui.LevelText.text = save.LevelText;
			#endregion

			#region Security
			ActivePayDaySecurity = save.ActivePayDaySecurity;
			ActiveDefenced = save.ActiveDefenced;
			attack = save.attack;
			#endregion

			#region Seller
			ActivePayDaySeller = save.ActivePayDaySeller;
			ActiveSaleSeller = save.ActiveSaleSeller;
			#endregion

			#region Time
			for(int i = 0; i < save.timeExit.Length; i++)
			{
				timeExit[i] = save.timeExit[i];
			}
			#endregion

			#region Tutorial
			tutorial = save.tutorial;
			#endregion

			#endregion

			ui.Background.GetComponent<Image>().sprite = ui.BackgroundList[ActiveBackground];
		}
	}

	private void ContinueGame()
	{
		if (PlayerPrefs.HasKey("SaveGame"))
		{
			DateTime date = new DateTime(timeExit[0], timeExit[1], timeExit[2], timeExit[3], timeExit[4], timeExit[5]);
			TimeSpan timeSpan = DateTime.Now - date;

			ui.SetMaxCountSlider(CapacityCar);

			#region Delivery
			TimeDeliverCar -= (float)timeSpan.TotalSeconds;
			if (TimeDeliverCar <= 0)
			{
				ui.DisplayDeliveryProduct(0, 0);
				ui.BoostDelivery.interactable = false;
				TimeDeliverCar = -0.1f;
				SaleProductInNextLevel += DeliveryProductInCar;
				CountProductInSale += DeliveryProductInCar;
				ProfitProduct += ReceiptsProductInCar;
				DeliveryProductInCar = 0;
				ReceiptsProductInCar = 0;
				CheckProductInStore = true;
			}
			else
			{
				timeManager.ResumptionCoroutine(0, 0);
			}
			#endregion

			#region SaleExit
			float timeSale = (float)timeSpan.TotalSeconds;
			float productSaleExit = 0f;
			if (timeSale > 30f)
			{
				productSaleExit = (timeSale / 30f) * ActiveSaleSeller;
			}
			if (CountProductInSale > (int)productSaleExit)
			{
				CountProductInSale -= (int)productSaleExit;
				timeManager.ResumptionCoroutine(2, 0);
			}
			else
			{
				money += ProfitProduct;
				EarnedMoneyDay += TempEarndeMoneyDay;
				ProfitProduct = 0;
				TempEarndeMoneyDay = 0;
				activeCapacityLocation = staticCapacityLocation;
				AllSaleProduct += SaleProductInNextLevel;
				message.PrintStatistics(7, AllSaleProduct, 0, 0f);
				message.PrintStatistics(8, 0, (int)EarnedMoneyDay, 0f);
				Point += SaleProductInNextLevel;
				SaleProductInNextLevel = 0;
				CountProductInSale = 0;
				CheckProductInStore = false;
			}
			#endregion

			#region PayDay
			TimePayDay += (float)timeSpan.TotalSeconds;
			if (TimePayDay >= 86400f)
			{
				TimePayDay = 0f;
				money -= PayDayStaff;
				EarnedMoneyDay = 0;
				message.PayDayAndAttackToKiosk(timeManager.AttackToKiosk());
				message.PrintStatistics(8, 0, (int)EarnedMoneyDay, 0);
			}
			timeManager.ResumptionCoroutine(1, 0);
			#endregion

			#region ContractTime
			for (int i = 0; i < timeContractProvider.Length; i++)
			{
				if (timeContractProvider[i] > -1f)
				{
					timeContractProvider[i] -= (float)timeSpan.TotalSeconds;
					if (timeContractProvider[i] < -1f)
					{
						message.PrintTimeContract(i, 0, 0);
						ui.ResetContractButton[i].interactable = false;
						timeContractProvider[i] = -1f;
						ui.UpdateContract(i);
					}
					else
					{
						timeManager.ResumptionCoroutine(3, i);
					}
				}
			}
			#endregion
		}
	}

	private void OnApplicationPause(bool pause)
	{
		if (pause == true)
		{
			#region UI
			for (int i = 0; i < save.AlcoholButton.Length; i++)
			{
				if (i < save.SecurityButton.Length)
				{
					save.SecurityButton[i] = ui.SecurityButton[i].interactable;
					save.SecurityText[i] = ui.SecurityText[i].text;
				}
				if (i < save.JuristButton.Length)
				{
					save.JuristButton[i] = ui.JuristButton[i].interactable;
					save.JuristText[i] = ui.JuristText[i].text;
				}
				if (i < save.ProvierButton.Length)
				{
					save.ProvierButton[i] = ui.ProviderButton[i].interactable;
					save.ResetContract[i] = ui.ResetContractButton[i].interactable;
					save.ProviderText[i] = ui.ProviderText[i].text;
					save.MarkupProductText[i] = ui.MarkupProductText[i].text;
					save.CigarettesButton[i] = ui.CigarettesButton[i].interactable;
				}
				if (i < save.CarButton.Length)
				{
					save.CarButton[i] = ui.CarButton[i].interactable;
					save.BeveragesButton[i] = ui.BeveragesButton[i].interactable;
					save.CarText[i] = ui.CarText[i].text;
				}
				if (i < save.BackeryButton.Length)
				{
					save.BackeryButton[i] = ui.BackeryButton[i].interactable;
				}
				if (i < ui.StoreButton.Length)
				{
					save.StoreButton[i] = ui.StoreButton[i].interactable;
				}
				if (i < save.SellerButton.Length)
				{
					save.SellerButton[i] = ui.SellerBttn[i].interactable;
					save.SellerHireText[i] = ui.SellerText[i].text;
				}
				if (i < save.SnacksButton.Length)
				{
					save.SnacksButton[i] = ui.SnacksButton[i].interactable;
				}
				save.AlcoholButton[i] = ui.AlcoholButton[i].interactable;
			}
			save.BoostDelivery = ui.BoostDelivery;
			#endregion

			#region VariableForClasses

			#region Car
			save.PayDayCar = PayDayCar;
			save.SpeedDeliveryCar = SpeedDeliveryCar;
			save.CapacityCar = CapacityCar;
			save.DeliveryProductInCar = DeliveryProductInCar;
			save.ReceiptsProductInCar = ReceiptsProductInCar;
			save.TimeDeliverCar = TimeDeliverCar;
			#endregion

			#region Jurist
			save.ActivePowerJurist = ActivePowerJurist;
			#endregion

			#region Location
			save.activeCapacityLocation = activeCapacityLocation;
			save.staticCapacityLocation = staticCapacityLocation;
			save.activeAssaultLocation = activeAssaultLocation;
			save.ActiveBackground = ActiveBackground;
			#endregion

			#region MainClick
			save.money = money;
			save.click = click;
			save.PayDayStaff = PayDayStaff;
			save.AllSaleProduct = AllSaleProduct;
			save.EarnedMoneyDay = EarnedMoneyDay;
			save.TempEarndeMoneyDay = TempEarndeMoneyDay;
			save.SaleProductInNextLevel = SaleProductInNextLevel;
			save.CheckProductInStore = CheckProductInStore;
			save.ProfitProduct = ProfitProduct;
			save.CountProductInSale = CountProductInSale;
			save.TimePayDay = TimePayDay;
			save.selectMusic = selectMusic;
			#endregion

			#region Message
			for (int i = 0; i < save.StatisticsText.Length; i++)
			{
				if (i < save.TimeContractProductText.Length)
				{
					save.TimeContractProductText[i] = message.TimeContactProductText[i].text;
				}
				save.StatisticsText[i] = message.StatisticsText[i].text;
			}
			#endregion

			#region Product
			save.MarkupBackery = MarkupBackery;
			save.MarkupSnacks = MarkupSnacks;
			save.MarkupBeverages = MarkupBeverages;
			save.MarkupCigarettes = MarkupCigarettes;
			save.MarkupAlcohol = MarkupAlcohol;
			for(int i = 0; i < save.activeAlcoholStorage.Length; i++)
			{
				if(i < save.activeCigarettesStorage.Length)
				{
					save.activeCigarettesStorage[i] = activeCigarettesStorage[i];
				}
				if(i < save.activeBeveragesStorage.Length)
				{
					save.activeBeveragesStorage[i] = activeBeveragesStorage[i];
				}
				if(i < save.activeBackeryStorage.Length)
				{
					save.activeBackeryStorage[i] = activeBackeryStorage[i];
				}
				if(i < save.activeSnacksStorage.Length)
				{
					save.activeSnacksStorage[i] = activeSnacksStorage[i];
				}
				save.activeAlcoholStorage[i] = activeAlcoholStorage[i];
			}
			#endregion

			#region Provider
			for(int i = 0; i < save.timeContractProvider.Length; i++)
			{
				save.timeContractProvider[i] = timeContractProvider[i];
			}
			#endregion

			#region RPGSystem
			save.bonusMoney = bonusMoney;
			save.Level = Level;
			save.Point = Point;
			save.LevelText = ui.LevelText.text;
			#endregion

			#region Security
			save.ActivePayDaySecurity = ActivePayDaySecurity;
			save.ActiveDefenced = ActiveDefenced;
			save.attack = attack;
			#endregion

			#region Seller
			save.ActivePayDaySeller = ActivePayDaySeller;
			save.ActiveSaleSeller = ActiveSaleSeller;
			#endregion

			#region Time
			save.timeExit[0] = DateTime.Now.Year;
			save.timeExit[1] = DateTime.Now.Month;
			save.timeExit[2] = DateTime.Now.Day;
			save.timeExit[3] = DateTime.Now.Hour;
			save.timeExit[4] = DateTime.Now.Minute;
			save.timeExit[5] = DateTime.Now.Second;
			#endregion

			#region Tutorial
			save.tutorial = tutorial;
			#endregion
			#endregion

			PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(save));
		}
	}

	private void OnApplicationFocus(bool focus)
	{
		if (focus)
		{
			if(TimeDeliverCar > 0f)
			{
				TimeDeliverCar -= (DateTime.Now - pauseTime).Seconds;
				if(TimeDeliverCar <= 1f)
				{
					TimeDeliverCar = 1f;
				}
			}
		}
		else
		{
			pauseTime = DateTime.Now;
		}
	}

	private void OnApplicationQuit()
	{
		#region UI
		for (int i = 0; i < save.AlcoholButton.Length; i++)
		{
			if (i < save.SecurityButton.Length)
			{
				save.SecurityButton[i] = ui.SecurityButton[i].interactable;
				save.SecurityText[i] = ui.SecurityText[i].text;
			}
			if (i < save.JuristButton.Length)
			{
				save.JuristButton[i] = ui.JuristButton[i].interactable;
				save.JuristText[i] = ui.JuristText[i].text;
			}
			if (i < save.ProvierButton.Length)
			{
				save.ProvierButton[i] = ui.ProviderButton[i].interactable;
				save.ResetContract[i] = ui.ResetContractButton[i].interactable;
				save.ProviderText[i] = ui.ProviderText[i].text;
				save.MarkupProductText[i] = ui.MarkupProductText[i].text;
				save.CigarettesButton[i] = ui.CigarettesButton[i].interactable;
			}
			if (i < save.CarButton.Length)
			{
				save.CarButton[i] = ui.CarButton[i].interactable;
				save.BeveragesButton[i] = ui.BeveragesButton[i].interactable;
				save.CarText[i] = ui.CarText[i].text;
			}
			if (i < save.BackeryButton.Length)
			{
				save.BackeryButton[i] = ui.BackeryButton[i].interactable;
			}
			if (i < ui.StoreButton.Length)
			{
				save.StoreButton[i] = ui.StoreButton[i].interactable;
			}
			if (i < save.SellerButton.Length)
			{
				save.SellerButton[i] = ui.SellerBttn[i].interactable;
				save.SellerHireText[i] = ui.SellerText[i].text;
			}
			if (i < save.SnacksButton.Length)
			{
				save.SnacksButton[i] = ui.SnacksButton[i].interactable;
			}
			save.AlcoholButton[i] = ui.AlcoholButton[i].interactable;
		}
		save.BoostDelivery = ui.BoostDelivery;
		#endregion

		#region VariableForClasses

		#region Car
		save.PayDayCar = PayDayCar;
		save.SpeedDeliveryCar = SpeedDeliveryCar;
		save.CapacityCar = CapacityCar;
		save.DeliveryProductInCar = DeliveryProductInCar;
		save.ReceiptsProductInCar = ReceiptsProductInCar;
		save.TimeDeliverCar = TimeDeliverCar;
		#endregion

		#region Jurist
		save.ActivePowerJurist = ActivePowerJurist;
		#endregion

		#region Location
		save.activeCapacityLocation = activeCapacityLocation;
		save.staticCapacityLocation = staticCapacityLocation;
		save.activeAssaultLocation = activeAssaultLocation;
		save.ActiveBackground = ActiveBackground;
		#endregion

		#region MainClick
		save.money = money;
		save.click = click;
		save.PayDayStaff = PayDayStaff;
		save.AllSaleProduct = AllSaleProduct;
		save.EarnedMoneyDay = EarnedMoneyDay;
		save.TempEarndeMoneyDay = TempEarndeMoneyDay;
		save.SaleProductInNextLevel = SaleProductInNextLevel;
		save.CheckProductInStore = CheckProductInStore;
		save.ProfitProduct = ProfitProduct;
		save.CountProductInSale = CountProductInSale;
		save.TimePayDay = TimePayDay;
		save.selectMusic = selectMusic;
		#endregion

		#region Message
		for (int i = 0; i < save.StatisticsText.Length; i++)
		{
			if (i < save.TimeContractProductText.Length)
			{
				save.TimeContractProductText[i] = message.TimeContactProductText[i].text;
			}
			save.StatisticsText[i] = message.StatisticsText[i].text;
		}
		#endregion

		#region Product
		save.MarkupBackery = MarkupBackery;
		save.MarkupSnacks = MarkupSnacks;
		save.MarkupBeverages = MarkupBeverages;
		save.MarkupCigarettes = MarkupCigarettes;
		save.MarkupAlcohol = MarkupAlcohol;
		for (int i = 0; i < save.activeAlcoholStorage.Length; i++)
		{
			if (i < save.activeCigarettesStorage.Length)
			{
				save.activeCigarettesStorage[i] = activeCigarettesStorage[i];
			}
			if (i < save.activeBeveragesStorage.Length)
			{
				save.activeBeveragesStorage[i] = activeBeveragesStorage[i];
			}
			if (i < save.activeBackeryStorage.Length)
			{
				save.activeBackeryStorage[i] = activeBackeryStorage[i];
			}
			if (i < save.activeSnacksStorage.Length)
			{
				save.activeSnacksStorage[i] = activeSnacksStorage[i];
			}
			save.activeAlcoholStorage[i] = activeAlcoholStorage[i];
		}
		#endregion

		#region Provider
		for (int i = 0; i < save.timeContractProvider.Length; i++)
		{
			save.timeContractProvider[i] = timeContractProvider[i];
		}
		#endregion

		#region RPGSystem
		save.bonusMoney = bonusMoney;
		save.Level = Level;
		save.Point = Point;
		save.LevelText = ui.LevelText.text;
		#endregion

		#region Security
		save.ActivePayDaySecurity = ActivePayDaySecurity;
		save.ActiveDefenced = ActiveDefenced;
		save.attack = attack;
		#endregion

		#region Seller
		save.ActivePayDaySeller = ActivePayDaySeller;
		save.ActiveSaleSeller = ActiveSaleSeller;
		#endregion

		#region Time
		save.timeExit[0] = DateTime.Now.Year;
		save.timeExit[1] = DateTime.Now.Month;
		save.timeExit[2] = DateTime.Now.Day;
		save.timeExit[3] = DateTime.Now.Hour;
		save.timeExit[4] = DateTime.Now.Minute;
		save.timeExit[5] = DateTime.Now.Second;
		#endregion

		#region Tutorial
		save.tutorial = tutorial;
		#endregion

		#endregion
		PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(save));
	}

	public void Restart()
	{
		PlayerPrefs.DeleteKey("SaveGame");
		PlayerPrefs.DeleteKey("SaveLoadScene");
		SceneManager.LoadScene("MainScene");
	}
}

[Serializable]
public class Save
{
	#region UI
	public bool[] CarButton = new bool[6];
	public string[] CarText = new string[6];
	public bool BoostDelivery;

	public bool[] JuristButton = new bool[3];
	public string[] JuristText = new string[3];

	public bool[] SellerButton = new bool[9];
	public string[] SellerHireText = new string[9];

	public bool[] BackeryButton = new bool[7];
	public bool[] SnacksButton = new bool[14];
	public bool[] BeveragesButton = new bool[6];
	public bool[] CigarettesButton = new bool[5];
	public bool[] AlcoholButton = new bool[15];
	public string[] MarkupProductText = new string[5];

	public bool[] ProvierButton = new bool[5];
	public bool[] ResetContract = new bool[5];
	public string[] ProviderText = new string[5];

	public bool[] SecurityButton = new bool[2];
	public string[] SecurityText = new string[2];

	public bool[] StoreButton = new bool[8];
	#endregion

	#region Car
	public float PayDayCar;
	public float SpeedDeliveryCar;
	public int CapacityCar;
	public int DeliveryProductInCar;
	public float ReceiptsProductInCar;
	public float TimeDeliverCar;
	#endregion

	#region Jurist
	public int ActivePowerJurist;
	#endregion

	#region Location
	public int activeCapacityLocation;
	public int staticCapacityLocation;
	public int activeAssaultLocation;
	public int ActiveBackground;
	#endregion

	#region MainClick
	public float money;
	public int click;
	public float PayDayStaff;
	public int AllSaleProduct;
	public float EarnedMoneyDay; // Заработано денег в день
	public float TempEarndeMoneyDay; // Временная переменная для хранения значения во время доставки и продажи товара
	public int SaleProductInNextLevel;
	public bool CheckProductInStore;
	public float ProfitProduct;
	public int CountProductInSale;
	public float TimePayDay;
	public int selectMusic;
	#endregion

	#region Message
	public string[] TimeContractProductText = new string[5];
	public string[] StatisticsText = new string[9];
	#endregion

	#region Product
	public int MarkupBackery;
	public int MarkupSnacks;
	public int MarkupBeverages;
	public int MarkupCigarettes;
	public int MarkupAlcohol;
	public int[] activeBackeryStorage = new int[7];
	public int[] activeSnacksStorage = new int[14];
	public int[] activeBeveragesStorage = new int[6];
	public int[] activeCigarettesStorage = new int[5];
	public int[] activeAlcoholStorage = new int[15];
	#endregion

	#region Provider
	public float[] timeContractProvider = new float[5];
	#endregion

	#region RPGSystem
	public float bonusMoney = 50;
	public int Level = 1;
	public int Point;
	public string LevelText;
	#endregion

	#region Security
	public float ActivePayDaySecurity;
	public int ActiveDefenced;
	public bool attack;
	#endregion

	#region Seller
	public float ActivePayDaySeller;
	public int ActiveSaleSeller;
	#endregion

	#region Time
	public int[] timeExit = new int[6];
	#endregion

	#region Tutorial
	public bool tutorial;
	#endregion
}
