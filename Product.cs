using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
	[SerializeField]
	private int[] countBackery;
	[SerializeField]
	private int[] countSnacks;
	[SerializeField]
	private int[] countBeverages;
	[SerializeField]
	private int[] countCigarettes;
	[SerializeField]
	private int[] countAlcohol;
	[SerializeField]
	private float[] priceBakcery;
	[SerializeField]
	private float[] priceSnacks;
	[SerializeField]
	private float[] priceBeverages;
	[SerializeField]
	private float[] priceCigarettes;
	[SerializeField]
	private float[] priceAlcohol;

	private int multiplicationSelect = 1;
	private int countSliderSelect;

	public void ProductInStock(int select, int[] array)
	{
		switch (select)
		{
			case 0:
				foreach(int i in array)
				{
					ScriptManager.Instance.activeBackeryStorage[i] = countBackery[i];
				}
				break;
			case 1:
				foreach (int i in array)
				{
					ScriptManager.Instance.activeSnacksStorage[i] = countSnacks[i];
				}
				break;
			case 2:
				foreach (int i in array)
				{
					ScriptManager.Instance.activeBeveragesStorage[i] = countBeverages[i];
				}
				break;
			case 3:
				foreach (int i in array)
				{
					ScriptManager.Instance.activeCigarettesStorage[i] = countCigarettes[i];
				}
				break;
			default:
				foreach (int i in array)
				{
					ScriptManager.Instance.activeAlcoholStorage[i] = countAlcohol[i];
				}
				break;
		}
	}

	public void InfoProduct()
	{
		switch (UI.Instance.SelectSortProduct)
		{
			case 0:
				UI.Instance.InformationBuyProducte(true, ScriptManager.Instance.activeBackeryStorage[UI.Instance.SelectProduct], priceBakcery[UI.Instance.SelectProduct], multiplicationSelect);
				break;
			case 1:
				UI.Instance.InformationBuyProducte(true, ScriptManager.Instance.activeSnacksStorage[UI.Instance.SelectProduct], priceSnacks[UI.Instance.SelectProduct], multiplicationSelect);
				break;
			case 2:
				UI.Instance.InformationBuyProducte(true, ScriptManager.Instance.activeBeveragesStorage[UI.Instance.SelectProduct], priceBeverages[UI.Instance.SelectProduct], multiplicationSelect);
				break;
			case 3:
				UI.Instance.InformationBuyProducte(true, ScriptManager.Instance.activeCigarettesStorage[UI.Instance.SelectProduct], priceCigarettes[UI.Instance.SelectProduct], multiplicationSelect);
				break;
			default:
				UI.Instance.InformationBuyProducte(true, ScriptManager.Instance.activeAlcoholStorage[UI.Instance.SelectProduct], priceAlcohol[UI.Instance.SelectProduct], multiplicationSelect);
				break;
		}
	}

	public void PreparationProduct()
	{
		if (ScriptManager.Instance.SpeedDeliveryCar > 0f)
		{
			switch (UI.Instance.SelectSortProduct)
			{
				case 0:
					countSliderSelect = UI.Instance.InformationBuyProducte(true, ScriptManager.Instance.activeBackeryStorage[UI.Instance.SelectProduct], priceBakcery[UI.Instance.SelectProduct], multiplicationSelect);
					break;
				case 1:
					countSliderSelect = UI.Instance.InformationBuyProducte(true, ScriptManager.Instance.activeSnacksStorage[UI.Instance.SelectProduct], priceSnacks[UI.Instance.SelectProduct], multiplicationSelect);
					break;
				case 2:
					countSliderSelect = UI.Instance.InformationBuyProducte(true, ScriptManager.Instance.activeBeveragesStorage[UI.Instance.SelectProduct], priceBeverages[UI.Instance.SelectProduct], multiplicationSelect);
					break;
				case 3:
					countSliderSelect = UI.Instance.InformationBuyProducte(true, ScriptManager.Instance.activeCigarettesStorage[UI.Instance.SelectProduct], priceCigarettes[UI.Instance.SelectProduct], multiplicationSelect);
					break;
				default:
					countSliderSelect = UI.Instance.InformationBuyProducte(true, ScriptManager.Instance.activeAlcoholStorage[UI.Instance.SelectProduct], priceAlcohol[UI.Instance.SelectProduct], multiplicationSelect);
					break;
			}
		}
		else
		{
			Message.Instance.CallMessage("У вас не арендована машина");
		}
	}

	public void LoadProductToCar()
	{
		int countMultiplication = countSliderSelect;
		int sort = UI.Instance.SelectSortProduct;
		int product = UI.Instance.SelectProduct;
		float receipts;
		if (ScriptManager.Instance.TimeDeliverCar <= 1f)
		{
			if (countMultiplication <= ScriptManager.Instance.activeCapacityLocation)
			{
				if (countMultiplication != 0)
				{
					switch (sort)
					{
						case 0:
							if (ScriptManager.Instance.activeBackeryStorage[product] > 0 && countMultiplication <= ScriptManager.Instance.activeBackeryStorage[product])
							{
								if(ScriptManager.Instance.money >= countMultiplication * priceBakcery[product])
								{
									ScriptManager.Instance.money -= countMultiplication * priceBakcery[product];
									receipts = countMultiplication * (priceBakcery[product] + (priceBakcery[product] * ScriptManager.Instance.MarkupBackery / 100));
									ScriptManager.Instance.activeBackeryStorage[product] -= countMultiplication;
									ScriptManager.Instance.TempEarndeMoneyDay += receipts - (countMultiplication * priceBakcery[product]);
									ScriptManager.Instance.activeCapacityLocation -= countSliderSelect;
									TimeManager.Instance.DeliveryProduct(countMultiplication, receipts);
								}
								else
								{
									Message.Instance.CallMessage("Недостаточно денег");
								}
							}
							else
							{
								Message.Instance.CallMessage("Недостаточно продукции на складе");
							}
							break;
						case 1:
							if(ScriptManager.Instance.activeSnacksStorage[product] > 0 && countMultiplication <= ScriptManager.Instance.activeSnacksStorage[product])
							{
								if (ScriptManager.Instance.money >= countMultiplication * priceSnacks[product])
								{
									ScriptManager.Instance.money -= countMultiplication * priceSnacks[product];
									receipts = countMultiplication * (priceSnacks[product] + (priceSnacks[product] * ScriptManager.Instance.MarkupSnacks / 100));
									ScriptManager.Instance.activeSnacksStorage[product] -= countMultiplication;
									ScriptManager.Instance.TempEarndeMoneyDay += receipts - (countMultiplication * priceSnacks[product]);
									ScriptManager.Instance.activeCapacityLocation -= countMultiplication;
									TimeManager.Instance.DeliveryProduct(countMultiplication, receipts);
								}
								else
								{
									Message.Instance.CallMessage("Недостаточно денег");
								}
							}
							else
							{
								Message.Instance.CallMessage("Недостаточно продукции на складе");
							}
							break;
						case 2:
							if (ScriptManager.Instance.activeBeveragesStorage[product] > 0 && countMultiplication <= ScriptManager.Instance.activeBeveragesStorage[product])
							{
								if (ScriptManager.Instance.money >= countMultiplication * priceBeverages[product])
								{
									ScriptManager.Instance.money -= countMultiplication * priceBeverages[product];
									receipts = countMultiplication * (priceBeverages[product] + (priceBeverages[product] * ScriptManager.Instance.MarkupBeverages / 100));
									ScriptManager.Instance.activeBeveragesStorage[product] -= countMultiplication;
									ScriptManager.Instance.TempEarndeMoneyDay += receipts - (countMultiplication * priceBeverages[product]);
									ScriptManager.Instance.activeCapacityLocation -= countMultiplication;
									TimeManager.Instance.DeliveryProduct(countMultiplication, receipts);
								}
								else
								{
									Message.Instance.CallMessage("Недостаточно денег");
								}
							}
							else
							{
								Message.Instance.CallMessage("Недостаточно продукции на складе");
							}
							break;
						case 3:
							if(ScriptManager.Instance.activeCigarettesStorage[product] > 0 && countMultiplication <= ScriptManager.Instance.activeCigarettesStorage[product])
							{
								if(ScriptManager.Instance.money >= countMultiplication * priceCigarettes[product])
								{
									ScriptManager.Instance.money -= countMultiplication * priceCigarettes[product];
									receipts = countMultiplication * (priceCigarettes[product] + (priceCigarettes[product] * ScriptManager.Instance.MarkupCigarettes / 100));
									ScriptManager.Instance.activeBeveragesStorage[product] -= countMultiplication;
									ScriptManager.Instance.TempEarndeMoneyDay += receipts - (countMultiplication * priceCigarettes[product]);
									ScriptManager.Instance.activeCapacityLocation -= countMultiplication;
									TimeManager.Instance.DeliveryProduct(countMultiplication, receipts);
								}
								else
								{
									Message.Instance.CallMessage("Недостаточно денег");
								}
							}
							else
							{
								Message.Instance.CallMessage("Недостаточно продукции на складе");
							}
							break;
						default:
							if(ScriptManager.Instance.activeAlcoholStorage[product] > 0 && countMultiplication <= ScriptManager.Instance.activeAlcoholStorage[product])
							{

								if (ScriptManager.Instance.money >= countMultiplication * priceAlcohol[product])
								{
									ScriptManager.Instance.money -= countMultiplication * priceAlcohol[product];
									receipts = countMultiplication * (priceAlcohol[product] + (priceAlcohol[product] * ScriptManager.Instance.MarkupAlcohol / 100));
									ScriptManager.Instance.activeAlcoholStorage[product] -= countMultiplication;
									ScriptManager.Instance.TempEarndeMoneyDay += receipts - (countMultiplication * priceAlcohol[product]);
									ScriptManager.Instance.activeCapacityLocation -= countMultiplication;
									TimeManager.Instance.DeliveryProduct(countMultiplication, receipts);
								}
								else
								{
									Message.Instance.CallMessage("Недостаточно денег");
								}
							}
							else
							{
								Message.Instance.CallMessage("Недостаточно продукции на складе");
							}
							break;
					}
					countMultiplication = 0;
					UI.Instance.InformationBuyProducte(false, 0, 0, 0);
				}
			}
			else
			{
				Message.Instance.CallMessage("Недостаточно места в киоске");
			}
		}
		else
		{
			Message.Instance.CallMessage("Машина доставляет товар");
		}
	}

	public void Multiplication(int select)
	{
		if (select == 0)
		{
			multiplicationSelect = 1;
		}
		else if (select == 1)
		{
			multiplicationSelect = 5;
		}
		else
		{
			multiplicationSelect = 25;
		}
		UI.Instance.CountSliderMultiplication(select, ScriptManager.Instance.CapacityCar);
	}

	public void SelectLeftRightButton(int index)
	{
		if(index == 0)
		{
			UI.Instance.SelectCountSlider.value += 1;
			countSliderSelect = UI.Instance.InformationBuyProducte(true, ScriptManager.Instance.activeBackeryStorage[UI.Instance.SelectProduct], priceBakcery[UI.Instance.SelectProduct], multiplicationSelect);
		}
		else
		{
			UI.Instance.SelectCountSlider.value -= 1;
			countSliderSelect = UI.Instance.InformationBuyProducte(true, ScriptManager.Instance.activeBackeryStorage[UI.Instance.SelectProduct], priceBakcery[UI.Instance.SelectProduct], multiplicationSelect);
		}
	}
}
