using UnityEngine;
using System.Collections;

public class UIEnemyScript : MonoBehaviour {

	public void EnemyOnClick()
	{
		Debug.Log("Enemy Clicked!");
	}

	public void KillOnClick()
	{
		Debug.Log("Kill Clicked!");
		Destroy(GameControl.selectedObject);
		this.GetComponentInParent<UIScript>().HideUI();
	}
}
