using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroSceneButton : MonoBehaviour {

	public void onClickPlay()
	{
		SceneManager.LoadScene("GameScene");
	}
}
