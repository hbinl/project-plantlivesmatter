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

    public static float healTimer = 3;
    public GameObject timerSlider;

    void Start()
    {
        timerSlider.SetActive(false);
    }

    public void Update()
    {
        if (healTimer < 3f)
        {
            timerSlider.SetActive(true);
            healTimer += Time.deltaTime;
            timerSlider.GetComponent<Slider>().value = healTimer;
        }
        else
        {
            // can be any number as long as bigger than 1f which is inside the if command
            healTimer = 10f;
            timerSlider.GetComponent<Slider>().value = 0f;
            timerSlider.SetActive(false);
        }
    }

	public void SueButtonClick()
	{
		if (!GameControl.wavesEnded && Time.timeScale != 0)
		{
			// add suepaper to user data
			Debug.Log("YEAH");
            GetComponent<AudioSource>().Play();
			UserInGameProgress.suePaperPurchased += 1;

			// tracking
			UserMovementTracker.SuePaperTrack ();

            sueActive = GameControl.PurchaseSuePaper();
            if (!sueActive)
            {
                //suePaper.color = Color;
            }         
        }
	}

	public void TreeButtonClick()
	{
        // if the game is not ended
        if (!GameControl.wavesEnded && Time.timeScale != 0)
		{
			// if player has enough money
			if (GameControl.coinValue >= 100)
			{
                defaultButtonColor();
                GetComponent<AudioSource>().Play();
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
        if (!GameControl.wavesEnded && Time.timeScale != 0)
        {
            defaultButtonColor();
            GetComponent<AudioSource>().Play();
            water.color = Color.yellow;
            GameControl.OnWaterButtonClick();
        }
    }

	public void MedicineButtonClick()
	{
        if (!GameControl.wavesEnded && Time.timeScale != 0 && healTimer >= 3f)
        {
            defaultButtonColor();
            GetComponent<AudioSource>().Play();
            heal.color = Color.yellow;
            GameControl.OnMedicineButtonClick();
        }  
    }

	public void SellButtonClick()
	{
        if (!GameControl.wavesEnded && Time.timeScale != 0)
        {
            defaultButtonColor();
            GetComponent<AudioSource>().Play();
            sell.color = Color.yellow;
            GameControl.OnSellButtonClick();
        }
	}

    public void defaultButtonColor()
    {
        if (!GameControl.wavesEnded && Time.timeScale != 0)
        {
            spawnTree.color = original;
            suePaper.color = original;
            water.color = original;
            heal.color = original;
            sell.color = original;
        }
    }
}
