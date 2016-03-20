using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
    public Image suePaper;
    public Image spawnTree;
    public Image water;
    public Image heal;
    public Image sell;

    public bool sueActive;
    private Color original = new Color(255,255,255);

	public void SueButtonClick()
	{
		if (!GameControl.wavesEnded)
		{
            sueActive = GameControl.PurchaseSuePaper();
            if (!sueActive)
            {
                //suePaper.color = Color;
            }         
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
                defaultButtonColor();
                spawnTree.color = Color.yellow;
				GameControl.OnTreeButtonClick();      
			}
            else
            {
                spawnTree.color = original;
            }
        }
	}

	public void WaterButtonClick()
	{
        if (!GameControl.wavesEnded)
        {
            Debug.Log("waterClicked");
            defaultButtonColor();
            water.color = Color.yellow;
            GameControl.OnWaterButtonClick();
        }
    }

	public void MedicineButtonClick()
	{
        if (!GameControl.wavesEnded)
        {
            defaultButtonColor();
            heal.color = Color.yellow;
            GameControl.OnMedicineButtonClick();
        }  
    }

	public void SellButtonClick()
	{
        if (!GameControl.wavesEnded)
        {
            Debug.Log("SELL");
            defaultButtonColor();
            sell.color = Color.yellow;
            GameControl.OnSellButtonClick();
        }
	}

    public void defaultButtonColor()
    {
        if (!GameControl.wavesEnded)
        {
            spawnTree.color = original;
            suePaper.color = original;
            water.color = original;
            heal.color = original;
            sell.color = original;
        }
    }
}
