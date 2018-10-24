using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	public static UI Instance;

	private void Awake()
	{
		Instance = this;
	}

	private void OnDestroy()
	{
		Instance = null;
	}

	#region Car
	[Header("Car")]
	public Button[] CarButton;
	public Text[] CarText;
	public Button BoostDelivery;
	#region Function
	public void LeaseCar(int select)
	{
		for (int i = 0; i < CarText.Length; i++)
		{
			if (CarText[i].text != "Заблокировано")
			{
				CarButton[i].interactable = true;
				CarText[i].text = "Арендовать";
			}
		}
		CarButton[select].interactable = false;
		CarText[select].text = "Арендовано";
	}
	#endregion
	#endregion

	#region Jurist
	[Header("Jurist")]
	public Button[] JuristButton;
	public Text[] JuristText;
	#region Function
	public void HireAndLeaveJurist(int select, bool flag)
	{
		if (flag)
		{
			JuristText[select].text = "Нанят";
			JuristButton[select].interactable = false;
		}
		else
		{
			for (int i = 0; i < JuristText.Length; i++)
			{
				if (JuristText[i].text != "Заблокировано")
				{
					JuristText[i].text = "Нанять";
					JuristButton[i].interactable = true;
				}
			}
		}
	}
	#endregion
	#endregion

	#region Seller
	[Header("Seller")]
	public Button[] SellerBttn;
	public Text[] SellerText;
	#region Function
	public void HireSeller(int select)
	{
		for (int i = 0; i < SellerText.Length; i++)
		{
			if (SellerText[i].text != "Заблокировано")
			{
				SellerText[i].text = "Нанять";
				SellerBttn[i].interactable = true;
			}
			SellerText[select].text = "Работает";
			SellerBttn[i].interactable = false;
		}
	}
	#endregion
	#endregion

	#region Product
	[Header("Product")]
	[SerializeField]
	private GameObject[] ProductPanel;
	[SerializeField]
	private GameObject BuyProductPanel;
	[SerializeField]
	private Text NameProduct;
	[SerializeField]
	private string[] nameBackery;
	[SerializeField]
	private string[] nameSnacks;
	[SerializeField]
	private string[] nameBeverages;
	[SerializeField]
	private string[] nameCigarettes;
	[SerializeField]
	private string[] nameAlcohol;
	public Slider SelectCountSlider;
	[SerializeField]
	private Text InfoBuyProduct;
	public Button[] BackeryButton;
	public Button[] SnacksButton;
	public Button[] BeveragesButton;
	public Button[] CigarettesButton;
	public Button[] AlcoholButton;
	public Text[] MarkupProductText;
	public Button[] MarkupProductButton;
	public int SelectSortProduct { get; set; }
	public int SelectProduct { get; set; }
	#region Function
	public void ActiveProductPanel(int select)
	{
		for (int i = 0; i < ProductPanel.Length; i++)
		{
			ProductPanel[i].SetActive(false);
		}
		ProductPanel[select].SetActive(true);
		SelectSortProduct = select;
	}

	public void ActiveBuyProductPanel(int select)
	{
		SelectCountSlider.value = 0;
		switch (SelectSortProduct)
		{
			case 0:
				NameProduct.text = nameBackery[select];
				break;
			case 1:
				NameProduct.text = nameSnacks[select];
				break;
			case 2:
				NameProduct.text = nameBeverages[select];
				break;
			case 3:
				NameProduct.text = nameCigarettes[select];
				break;
			default:
				NameProduct.text = nameAlcohol[select];
				break;
		}
		SelectProduct = select;
		BuyProductPanel.SetActive(!BuyProductPanel.activeSelf);
	}

	public void CountSliderMultiplication(int select, int capacityCar)
	{
		SelectCountSlider.value = 0;
		if (select == 0)
		{
			SelectCountSlider.maxValue = capacityCar / 1;
		}
		else if (select == 1)
		{
			SelectCountSlider.maxValue = capacityCar / 5;
		}
		else
		{
			SelectCountSlider.maxValue = capacityCar / 25;
		}
	}

	public int InformationBuyProducte(bool flag, int startCount, float price, int multiplication)
	{
		if (flag)
		{
			InfoBuyProduct.text = "На складе: " + startCount + "\nВыбрано: " + (SelectCountSlider.value * multiplication) + "\nЦена: " + (price * ((int)SelectCountSlider.value * multiplication)) + "$";
			return (int)SelectCountSlider.value * multiplication;
		}
		else
		{
			InfoBuyProduct.text = "На складе: " + 0 + "\nВыбрано: " + 0 + "\nЦена: " + 0 + "$";
			BuyProductPanel.SetActive(false);
			return 0;
		}
	}

	public void SetMaxCountSlider(int count)
	{
		SelectCountSlider.maxValue = count;
	}
	#endregion
	#endregion

	#region Provider
	[Header("Provider")]
	public Button[] ProviderButton;
	public Text[] ProviderText;
	public Button[] ResetContractButton;
	public GameObject PanelResetContract;
	#region Function
	public void ActiveProduct(int select, int[] array)
	{
		switch (select)
		{
			case 0:
				foreach (int i in array)
				{
					BackeryButton[i].interactable = true;
				}
				break;
			case 1:
				foreach (int i in array)
				{
					SnacksButton[i].interactable = true;
				}
				break;
			case 2:
				foreach (int i in array)
				{
					BeveragesButton[i].interactable = true;
				}
				break;
			case 3:
				foreach (int i in array)
				{
					CigarettesButton[i].interactable = true;
				}
				break;
			default:
				foreach (int i in array)
				{
					AlcoholButton[i].interactable = true;
				}
				break;
		}
		if (ProviderText[select].text != "Заблокировано")
		{
			ProviderText[select].text = "Заключен";
			ProviderButton[select].interactable = false;
		}
	}

	public void UpdateContract(int select)
	{
		ProviderText[select].text = "Заключить";
		ProviderButton[select].interactable = true;
		switch (select)
		{
			case 0:
				for (int i = 0; i < BackeryButton.Length; i++)
				{
					BackeryButton[i].interactable = false;
				}
				break;
			case 1:
				for (int i = 0; i < SnacksButton.Length; i++)
				{
					SnacksButton[i].interactable = false;
				}
				break;
			case 2:
				for (int i = 0; i < BeveragesButton.Length; i++)
				{
					BeveragesButton[i].interactable = false;
				}
				break;
			case 3:
				for (int i = 0; i < CigarettesButton.Length; i++)
				{
					CigarettesButton[i].interactable = false;
				}
				break;
			default:
				for (int i = 0; i < AlcoholButton.Length; i++)
				{
					AlcoholButton[i].interactable = false;
				}
				break;
		}
	}
	#endregion
	#endregion

	#region Security
	[Header("Security")]
	public Button[] SecurityButton;
	public Text[] SecurityText;
	#region Function
	public void HireAndLeaveSecurity(int select, bool flag)
	{
		if (flag)
		{
			SecurityText[select].text = "Работает";
			SecurityButton[select].interactable = false;
		}
		else
		{

			for (int i = 0; i < SecurityText.Length; i++)
			{
				if (SecurityText[i].text != "Заблокировано")
				{
					SecurityText[i].text = "Нанять";
					SecurityButton[i].interactable = true;
				}
			}
		}
	}
	#endregion
	#endregion

	#region Location
	[Header("Location")]
	public GameObject Background;
	public Sprite[] BackgroundList;
	public Button[] StoreButton;
	[SerializeField]
	private GameObject CapturePanel;
	[SerializeField]
	private Text[] InfoCapture;
	[SerializeField]
	private string[] nameLocation;
	[SerializeField]
	private string[] capacityLocation;
	[SerializeField]
	private string[] assaultLocation;
	[SerializeField]
	private string[] priceLocation;
	#region Function
	// Активация панелей карты
	public void TextCapturePanel(int select)
	{
		InfoCapture[0].text = nameLocation[select];
		InfoCapture[1].text = capacityLocation[select];
		InfoCapture[2].text = assaultLocation[select];
		InfoCapture[4].text = priceLocation[select];
		CapturePanel.SetActive(!CapturePanel.activeSelf);
	}

	public void ChanceInfoCapture(int chance)
	{
		InfoCapture[3].text = "3. Шанс захвата киоска: " + chance + "%";
	}

	public void NewLocation(int select)
	{ 
		StoreButton[select].interactable = false;
		if (select + 1 < StoreButton.Length)
		{
			Background.GetComponent<Image>().sprite = BackgroundList[select + 1];
			StoreButton[select + 1].interactable = true;
			ScriptManager.Instance.ActiveBackground = select + 1;
		}
		TextCapturePanel(select);
	}
	#endregion
	#endregion

	#region MainClick
	[Header("MainClick")]
	[SerializeField]
	private Text[] CountMoney;
	[SerializeField]
	private GameObject HelpPanel;
	[SerializeField]
	private Text InfoProductInStore;
	[SerializeField]
	private Text InfoDeliveryProduct;
	public Text LevelText;
	public Button CloseButton;

	#region Anim
	public GameObject clickPrefab, cliclParent;
	public ClickEffect[] clickImagePool;
	public Sprite[] clickImage;
	#endregion

	#region Function
	public void DisplayMoney(float money)
	{
		for (int i = 0; i < CountMoney.Length; i++)
		{
			CountMoney[i].text = "" + (int)money + "$";
		}
	}
	public void DisplayProductInStore(int product)
	{
		InfoProductInStore.text = "Продуктов: \n" + product;
	}
	public void DisplayDeliveryProduct(int minute, int second)
	{
		InfoDeliveryProduct.text = "Доставка: \n" + minute + ":" + second;
	}

	public void ActiveHelpPanel()
	{
		HelpPanel.SetActive(!HelpPanel.activeSelf);
	}
	#endregion
	#endregion

	#region ActiveMainPanel
	[Header("MainPanel")]
	[SerializeField]
	private GameObject[] MainPanel;
	[SerializeField]
	private GameObject[] UpgradePanel;
	#region Function
	// Активация главных панелей
	public void ActiveMainPanel(int select)
	{
		for (int i = 0; i < MainPanel.Length; i++)
		{
			if (i < 5)
			{
				UpgradePanel[i].SetActive(false);
			}
			if (i < 6)
			{
				ProductPanel[i].SetActive(false);
			}
			MainPanel[i].SetActive(false);
		}
		switch (select)
		{
			case 0:
				MainPanel[0].SetActive(true);
				MainPanel[5].SetActive(true);
				break;
			case 1:
				MainPanel[1].SetActive(true);
				MainPanel[2].SetActive(true);
				MainPanel[5].SetActive(true);
				break;
			case 2:
				MainPanel[1].SetActive(true);
				MainPanel[3].SetActive(true);
				MainPanel[5].SetActive(true);
				break;
			case 3:
				MainPanel[4].SetActive(true);
				MainPanel[7].SetActive(true);
				MainPanel[5].SetActive(true);
				break;
			case 4:
				break;
			default:
				MainPanel[6].SetActive(true);
				break;
		}
	}

	public void ActiveUpgradePanel(int select)
	{
		for (int i = 0; i < UpgradePanel.Length; i++)
		{
			UpgradePanel[i].SetActive(false);
		}
		UpgradePanel[select].SetActive(true);
	}
	#endregion
	#endregion
}
