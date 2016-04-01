using UnityEngine;
using System.Collections;

using System.IO;

public class FirstTimeRunScript : MonoBehaviour {

	void Awake () {


		UserDataBase ();
		AchievementDataBase ();
		HighscoreDataBase ();
		UserExpDataBase ();

	}

	void UserDataBase() {
		
		// create databases if does not exists (contain user and password)
		string path = Application.persistentDataPath + "/user_database";

		/*
		 *	Data format for each item in the list :
		 * 	user, password
		 */

		if (!File.Exists (path)) {
			string[] tmpData = {"ivan yang", "anson tio"};

			StreamWriter fileNew = new StreamWriter (path);

			foreach (string data in tmpData) {
				fileNew.WriteLine (data);
			}

			fileNew.Close ();
		}
	}

	void AchievementDataBase() {

		// create achievement datatabase if it does not exist
		string path = Application.persistentDataPath + "/achievement_list";

		/*
		 *	Data format for each item in the list :
		 * 	description, category, amount
		 */

		if (!File.Exists (path)) {
			string[] tmpData = {"100 trees plantation, tree, 100", 
				"heal trees 50 times, heal, 50",
				"survive 30 waves, wave, 30",
				"played for 1 hour, time, 216000",
				"purchased one item, item, 1",
			};

			StreamWriter fileNew = new StreamWriter (path);

			foreach (string data in tmpData) {
				fileNew.WriteLine (data);
			}

			fileNew.Close ();
		}
	}

	void HighscoreDataBase() {
		
		// create highscore datatabase if it does not exist
		string path = Application.persistentDataPath + "/highscore_list";

		/*
		 *	Data format for each item in the list :
		 * 	user, score, wave 
		 */

		if (!File.Exists (path)) {
			string[] tmpData = {"ivan 15000 23", 
				"anson 12000 17",
				"none 0 0",
				"none 0 0",
				"none 0 0",
				"none 0 0",
				"none 0 0",
				"none 0 0",
				"none 0 0",
				"none 0 0"};

			StreamWriter fileNew = new StreamWriter (path);

			foreach (string data in tmpData) {
				fileNew.WriteLine (data);
			}

			fileNew.Close ();
		}

	}

	void UserExpDataBase() {

		// create user data and experience datatabase if it does not exist
		string path = Application.persistentDataPath + "/personal_user";

		/*
		 *	Data format for each item in the list :
		 * 	user, achivement (in binary), wave total, time total, tree planted total, enemy killed,
		 * 		tree watered, tree heal, tree sell, sue paper purchased
		 */

		if (!File.Exists (path)) {
			string[] tmpData = {"ivan 00001 23 61200 30 40 5 0 10 50", 
				"anson 00101 17 54000 20 30 0 0 10 30"};

			StreamWriter fileNew = new StreamWriter (path);

			foreach (string data in tmpData) {
				fileNew.WriteLine (data);
			}

			fileNew.Close ();
		}

	}
}
