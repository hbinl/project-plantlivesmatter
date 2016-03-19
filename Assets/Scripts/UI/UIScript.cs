using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {
	
	public void SueButtonClick()
	{
		if (!GameControl.wavesEnded)
		{
			GameControl.PurchaseSuePaper();
		}
	}

	public void TreeButtonClick()
	{
		Debug.Log("tree Clicked");
		// if the game is not ended
		if (!GameControl.wavesEnded)
		{
			// if player has enough money
			if (GameControl.coinValue >= 100)
			{
				Debug.Log("BUY");
				GameControl.canSpawnTree = true;
				GameControl.OnTreeButtonClick();
			}
		}
	}

	public void WaterButtonClick()
	{
		GameControl.OnWaterButtonClick();
	}

	public void MedicineButtonClick()
	{
		GameControl.OnMedicineButtonClick();
	}

	public void SellButtonClick()
	{
		Debug.Log("SELL");
		GameControl.OnSellButtonClick();
	}
}
