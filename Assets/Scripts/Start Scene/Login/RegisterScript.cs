using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

using System;
using System.Linq;
using System.Collections.Generic;

public class RegisterScript : MonoBehaviour {

	public InputField inputUser;
	public InputField inputPassword;

	public GameObject login_form;

	public void onBackClick() {
		login_form.SetActive (true);
		this.gameObject.SetActive (false);
	}

	public void onProceedClick() {
		string user = inputUser.text;
		string password = inputPassword.text;

		//pre check if user input username and password at least 1 character
		if (user.Length == 0 || password.Length == 0) {
			Debug.Log("please input username and password");
		}

		if (CheckDatabase (user, password)) {
			Debug.Log ("Data Found, PLEASE INPUT OTHER USERNAME");
		} else {
			Debug.Log ("YAY, Registered");
			SetUserDataAndExp (user);
			SceneManager.LoadScene("IntroScene");
		}
	}

	bool CheckDatabase(string user, string password)
	{
		string path = Application.persistentDataPath + "/user_database";

		// in case user "too" clever and delete the database 
		if (!File.Exists (path)) {
			Debug.Log ("something wrong, call 911");
		}

		string[] THE_DATA = File.ReadAllLines (path);

		// check the data 1 by 1
		foreach (string DATA in THE_DATA) {
			string[] CURRENT_DATA = DATA.Split (' ');

			if (user == CURRENT_DATA [0]) {
				return true;
			}
		}

		// if not found, add user to database :D
		string content = user +" " + password + "\n";
		File.AppendAllText (path, content);


		// create the default user data and exp 
		path = Application.persistentDataPath + "/personal_user";
		//added goldleaf
		content = user + " 00000 0 0 0 0 0 0 0 0 0\n";
		File.AppendAllText(path, content);

		return false;
	}

	bool SetUserDataAndExp(string user) {
		string path = Application.persistentDataPath + "/personal_user";

		// in case user "too" clever and delete the database 
		if (!File.Exists (path)) {
			Debug.Log ("something wrong, call 911");
		}

		string[] THE_DATA = File.ReadAllLines (path);

		// check the data 1 by 1
		foreach (string DATA in THE_DATA) {
			string[] CURRENT_DATA = DATA.Split (' ');

			if (user == CURRENT_DATA [0]) {

				UserDataInGame.userData.username = CURRENT_DATA[0];
				UserDataInGame.userData.achievement = CURRENT_DATA[1];
				UserDataInGame.userData.wave = Int32.Parse(CURRENT_DATA[2]);
				UserDataInGame.userData.time = float.Parse(CURRENT_DATA[3]);
				UserDataInGame.userData.treePlanted = Int32.Parse(CURRENT_DATA[4]);
				UserDataInGame.userData.enemyKilled  = Int32.Parse(CURRENT_DATA[5]);
				UserDataInGame.userData.treeWatered = Int32.Parse(CURRENT_DATA[6]);
				UserDataInGame.userData.treeHealed = Int32.Parse(CURRENT_DATA[7]);
				UserDataInGame.userData.treeSold = Int32.Parse(CURRENT_DATA[8]);
				UserDataInGame.userData.suePaperPurchased = Int32.Parse(CURRENT_DATA[9]);
				//Added goldleaf
				UserDataInGame.userData.goldLeaf = Int32.Parse(CURRENT_DATA[10]);

				return true;
			}
		}

		return false;
	}
}
