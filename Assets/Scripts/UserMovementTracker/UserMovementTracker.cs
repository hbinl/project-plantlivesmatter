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
		
	}

	public static void SuePaperTrack() {
		moveTrack += "s";
	}

	public static void TreeTrack(Vector3 pos) {
		//CheckGridPosition (pos);
	}

	public static void EnemyTrack(Vector3 pos, bool leftSpawn, string enemyID) {

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

	void CheckGridPosition(Vector3 pos)
	{

	}
}
