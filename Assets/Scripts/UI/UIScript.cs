using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

	public UITreeScript treeUI;

	public void ShowTreeUI()
	{
		treeUI.gameObject.SetActive(true);
	}

	public void HideUI()
	{
		treeUI.gameObject.SetActive(false);
	}
}
