using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

	Object anObject;

	void Update () {
//		if (Input.GetMouseButtonDown(0))
//		{
////			Debug.Log(Input.mousePosition);
////			transform.position = new Vector3(Input.mousePosition.x,Input.mousePosition.y ,0f);
//		}
	}

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
	}
}
