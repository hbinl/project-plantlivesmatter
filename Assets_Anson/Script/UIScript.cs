using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

	public void ShowTreeUI()
	{
		this.gameObject.SetActive(true);
	}

	public void HideTreeUI()
	{
		this.gameObject.SetActive(false);
	}

	public void StatusOnClick()
	{
		Debug.Log("Status Clicked!");
	}

	public void KillOnClick()
	{
		Debug.Log("Kill Clicked!");
		Destroy(GameControl.selectedTree);
		this.HideTreeUI();
	}
}
