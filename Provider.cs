using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Provider : Staff
{
	[SerializeField]
	private int[] priceContract;
	
	private const float day = 86400f;

	public Product product;

	public override void Invite(int select)
	{
		int[] array = { -1, -2, -3 };
		if (ScriptManager.Instance.money >= priceContract[select])
		{
			ScriptManager.Instance.money -= priceContract[select];
			switch (select)
			{
				case 0:
					do
					{
						for (int i = 0; i < 3; i++)
						{
							array[i] = Random.Range(0, 7);
						}
					} while (array[1] == array[0] || array[2] == array[0] || array[1] == array[2]);
					break;
				case 1:
					do
					{
						for (int i = 0; i < 3; i++)
						{
							array[i] = Random.Range(0, 14);
						}

					} while (array[1] == array[0] || array[2] == array[0] || array[1] == array[2]);
					break;
				case 2:
					do
					{
						for (int i = 0; i < 3; i++)
						{
							array[i] = Random.Range(0, 6);
						}

					} while (array[1] == array[0] || array[2] == array[0] || array[1] == array[2]);
					break;
				case 3:
					do
					{
						for (int i = 0; i < 3; i++)
						{
							array[i] = Random.Range(0, 5);
						}

					} while (array[1] == array[0] || array[2] == array[0] || array[1] == array[2]);
					break;
				default:
					do
					{
						for (int i = 0; i < 3; i++)
						{
							array[i] = Random.Range(0, 15);
						}

					} while (array[1] == array[0] || array[2] == array[0] || array[1] == array[2]);
					break;
			}
			Audio.instance.playSound(4);
			UI.Instance.ActiveProduct(select, array);
			product.ProductInStock(select, array);
			ScriptManager.Instance.timeContractProvider[select] = day;
			UI.Instance.ResetContractButton[select].interactable = true;
			TimeManager.Instance.ResumptionCoroutine(3, select);
		}
		else
		{
			Message.Instance.CallMessage("Недостаточно денег");
		}
	}

	public void RestContract(int select)
	{
		ScriptManager.Instance.selectContact = select;
		UI.Instance.PanelResetContract.SetActive(true);
	}
}
