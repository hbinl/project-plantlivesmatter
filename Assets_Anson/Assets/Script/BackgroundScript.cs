using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

	public UIScript uiActivation;

	public void OnMouseOver()
	{
		// if right click on the background and is not clicking the UI
		if (Input.GetMouseButtonDown(0) && !UIUtilities.isCursorOnUI())
		{
			uiActivation.HideUI();
		}
	}
}
