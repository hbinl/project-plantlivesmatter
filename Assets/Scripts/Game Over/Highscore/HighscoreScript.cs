using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

using System;
using System.Linq;

public class HighscoreScript : MonoBehaviour {

	public Text highscoreText;

	// Use this for initialization
	void Awake () {
		string textResult = "";

		string path = Application.persistentDataPath + "/highscore_list";

		// in case user "too" clever and delete the database 
		if (!File.Exists (path)) {
			Debug.Log ("something wrong, call 911");
		}

		string[] THE_DATA = File.ReadAllLines (path);

		int counter = 1;
		foreach (string line in THE_DATA) {
			textResult += counter + " " + line + " " + "\n";
			counter++;
		}

		highscoreText.text = textResult;
	}
}
