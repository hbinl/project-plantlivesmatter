using UnityEngine;
using System.Collections;

public class UITreeScript : MonoBehaviour {

	public void TreeOnClick()
	{
		Debug.Log("Tree Clicked!");
	}

	public void KillOnClick()
	{
		Debug.Log("Kill Clicked!");
		Destroy(GameControl.selectedObject);
		this.GetComponentInParent<UIScript>().HideUI();
	}
}
