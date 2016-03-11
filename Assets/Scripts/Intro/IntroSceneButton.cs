using UnityEngine;
using System.Collections;

public class IntroSceneButton : MonoBehaviour {

	public void onClickPlay()
	{
		Application.LoadLevel("GameScene");
	}
}
