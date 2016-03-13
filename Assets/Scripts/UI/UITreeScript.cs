using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITreeScript : MonoBehaviour {

	public Slider healthSlider;
	public Image healthFillImage;

	public UIScript uiActivation;

	void Update()
	{
		SetHealthUI();
	}

	public void WaterOnClick()
	{
		// Water cost 10 coins
		if (GameControl.coinValue > 10 && GameControl.selectedObject.GetComponent<TreeSci>().onFire)
		{
			GameControl.coinValue -= 10;
			GameControl.selectedObject.GetComponent<TreeSci>().onFire = false;
			GameControl.selectedObject.GetComponent<Animator>().SetBool("treeFire",false);
		}
	}

	public void HealOnClick()
	{
		// Heal cost 30 each time clicked and heals 100%
		if (GameControl.coinValue > 30 && !(GameControl.selectedObject.GetComponent<TreeSci>().hp > 99f))
		{
			GameControl.coinValue -= 30;
			GameControl.selectedObject.GetComponent<TreeSci>().hp = 100f;
		}
	}

	public void SellOnClick()
	{
		// Money increase depends on the tree health
		GameControl.coinValue += (int) GameControl.selectedObject.GetComponent<TreeSci>().hp;
		Destroy(GameControl.selectedObject.gameObject);
		uiActivation.HideUI();
	}

	private void SetHealthUI ()
	{
		// Set the slider's value appropriately.
		float healthValue = GameControl.selectedObject.GetComponent<TreeSci>().hp;
		healthSlider.value = healthValue;

		// Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
		healthFillImage.color = Color.Lerp (Color.red, Color.green, healthValue / 100f);
	}
}
