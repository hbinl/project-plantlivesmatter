using UnityEngine;
using System.Collections;

using System.IO;
using System;

public class UserMovementTracker : MonoBehaviour {

	public static string moveTrack;
	public static string trackResult;

	void Awake () {
		moveTrack = "";
		trackResult = "";
	}
	
	public static void CoinTrack(Vector3 pos) {
		moveTrack += "c";
		moveTrack += Convert.ToString( CheckGridPosition (pos));
	}

	public static void SuePaperTrack() {
		moveTrack += "s";
	}

	public static void TreeTrack(Vector3 pos, string treeInteraction) {
		moveTrack += "t";
		moveTrack += treeInteraction;
		moveTrack += Convert.ToString( CheckGridPosition (pos));
	}

	public static void EnemyTrack(Vector3 pos, bool leftSpawn, string enemyID) {
		
		moveTrack += "e";
		if (leftSpawn) {
			moveTrack += "l";
		} else {
			moveTrack += "r";
		}
		moveTrack += enemyID[0];
		moveTrack += CheckGridPosition(pos)[0];

	}

	public static void WaveTrack(int waveNum) {
		moveTrack += "w" + waveNum;
	}

	public static void UserStatusTrack(float currentScore, int treeNum, int suePaperNum, int coinNum) {
		moveTrack += "\n";
		moveTrack += "score" + currentScore + "tree" + treeNum + "sp" + suePaperNum + "cn" + coinNum;
	}


	public static void NextWaveTrack() {
		trackResult += moveTrack + "\n";
		trackResult += "----------\n";
		moveTrack = "";
	}

	public static void SaveToFile() {
//		Debug.Log (UserDataInGame.userData.username);

		string nowDateAndTime = Convert.ToString( DateTime.Now.ToOADate());
		nowDateAndTime = nowDateAndTime.Replace ('.', '_');
		string path = Application.persistentDataPath + "/m_" + UserDataInGame.userData.username + "_" + nowDateAndTime ;

		File.Create(path).Dispose();

		File.WriteAllText (path, trackResult);
	}

	public static string CheckGridPosition(Vector3 pos)
	{
		int row, col;
		row = 0;
		col = 0;

		if (pos.y > 0.2f) {
			row = 1;
		} else if (pos.y > -2.2f && pos.y <= 0.2f) {
			row = 2;
		} else if (pos.y <= -2.2f) {
			row = 3;
		}

		if (pos.x < -3.25f) {
			col = 1;
		} else if (pos.x < -0.9f && pos.x >= -3.25f) {
			col = 2;
		} else if (pos.x < 1.1f && pos.x >= -0.9f) {
			col = 3;
		} else if (pos.x < 3.3f && pos.x >= 1.1f) {
			col = 4;
		} else if (pos.x >= 3.3f) {
			col = 5;
		}

		return row + "" + col + "";
	}
}
