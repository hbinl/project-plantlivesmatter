using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControl : MonoBehaviour {

	public UIScript uiPosition;

	public void ShowTreeUI()
	{
		uiPosition.transform.position = new Vector3(Input.mousePosition.x,Input.mousePosition.y ,-10f);;
		uiPosition.ShowTreeUI();
	}

	public void HideTreeUI()
	{
		uiPosition.HideTreeUI();
	}
}
