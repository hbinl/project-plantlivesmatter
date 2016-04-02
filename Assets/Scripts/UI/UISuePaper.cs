using UnityEngine;
using System.Collections;

public class UISuePaper : MonoBehaviour {

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0) && !GameControl.wavesEnded)
		{
			// add suepaper to user data
			UserInGameProgress.suePaperPurchased += 1;

			GameControl.PurchaseSuePaper();
		}
	}
}
