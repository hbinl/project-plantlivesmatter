using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

	public UITreeScript treeUI;
	public UIEnemyScript enemyUI;

	public void ShowTreeUI()
	{
		treeUI.gameObject.SetActive(true);
		enemyUI.gameObject.SetActive(false);
	}

	public void HideUI()
	{
		treeUI.gameObject.SetActive(false);
		enemyUI.gameObject.SetActive(false);
	}


	public void ShowEnemyUI()
	{
		treeUI.gameObject.SetActive(false);
		enemyUI.gameObject.SetActive(true);
	}
}
