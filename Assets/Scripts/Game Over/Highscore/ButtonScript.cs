using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

	public void onHomeButtonClick() {
		Debug.Log ("Click");
		SceneManager.LoadScene("IntroScene");
	}
}
