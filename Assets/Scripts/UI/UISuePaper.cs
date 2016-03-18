using UnityEngine;
using System.Collections;

public class UISuePaper : MonoBehaviour {

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0) && !GameControl.wavesEnded)
		{
			GameControl.PurchaseSuePaper();
		}
	}
}
