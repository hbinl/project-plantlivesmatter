using UnityEngine;
using System.Collections;

using System.IO;
using System;

public class UserMovementTracker : MonoBehaviour {

	public static string moveTrack;
	public static string trackResult;

	static string lastPost;

	/*
	 * The format of the tracking will be :
	 * W1  [5,2]003230  [2,2]001230  [1,2]103230  [3,2]003230  [3,1]003230  [4,2]003230
	 * 
	 * A possible player behaviour at a position could be: [5,2]003230. 
	 * This mean at row5,column2, no coin purchased, no enemy sued, killed an enemy, 
	 * at right spawn point, flame type, and no tree planted.
	 * 
	 * Possible actions at each position:
	 * 1 = Got coins
	 * 2 = Sued paper bought
	 * 3 = Killed enemy = [left spawn point =1, right spawn point=2, type=[1=chainsaw,2=bulldozer,3=flame]]
	 * 4 = Planted tree = [1=sold, 2= healed,3=watered, 4=plant]
	 */

	void Awake () {
		moveTrack = "";
		trackResult = "";
		lastPost = "";
	}
	
	public static void CoinTrack(Vector3 pos) {
		// example : [5,2]100000
		lastPost = Convert.ToString( CheckGridPosition (pos));
		moveTrack += lastPost;
		moveTrack += "1000000 "; 
	}

	public static void SuePaperTrack() {
		// example : [5,2]010000
		moveTrack += lastPost;
		moveTrack += "020000 ";
	}

	public static void TreeTrack(Vector3 pos, string treeInteraction) {
		/* example : [5,2]00000x
		 * where x can be 0 to 4
		 * 0 : no tree interaction (when this occur, there is something wrong)
		 * 1 : Sell
		 * 2 : Heal
		 * 3 : Water
		 * 4 : Plant
		 */
		lastPost = Convert.ToString( CheckGridPosition (pos));
		moveTrack += lastPost;
		moveTrack += "00000";

		switch (treeInteraction) 
		{
			case "S":
				moveTrack += "1 ";
				break;
			case "H":
				moveTrack += "2 ";
				break;
			case "W":
				moveTrack += "3 ";
				break;
			case "P":
				moveTrack += "4 ";
				break;

			default:
				moveTrack += "0 ";
				break;
		}

	}

	public static void EnemyTrack(Vector3 pos, bool leftSpawn, string enemyID) {
		/*
		 * example : [5,2]003st0
		 * 3 : means enemy
		 * s : the spawn position, 1 means left, 2 means right
		 * t : enemy type, 1=chainsaw, 2=bulldozer, 3=flame, 0= something wrong with the enemy id
		 */

		lastPost = Convert.ToString( CheckGridPosition (pos));
		moveTrack += lastPost;
		moveTrack += "003";
		if (leftSpawn) {
			moveTrack += "1";
		} else {
			moveTrack += "2";
		}

		switch (enemyID[0]) {
		case 'C':
			moveTrack += "1";
			break;
		case 'B':
			moveTrack += "2";
			break;
		case 'F':
			moveTrack += "3";
			break;
		default:
			moveTrack += "0";
			break;
		}

		moveTrack += "0 ";

	}

	public static void WaveTrack(int waveNum) {
		// example: W1 --> Wave one
		moveTrack += "W" + waveNum + " ";
	}

	public static void UserStatusTrack(float currentScore, int treeNum, int suePaperNum, int coinNum) {
		// example: [8400,0,0,13]. This means user score = 8400, tree left = 0, sue paper left = 0, coins remaining = 13
		moveTrack += "[" + currentScore + "," + treeNum + "," + suePaperNum + "," + coinNum + "] ";
	}


	public static void NextWaveTrack() {
		trackResult += moveTrack + "\n";
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
		/* The total number of row : 3 and column is 7. below is the grid
		 * 
		 * 				Screen 
		 *     0   1   2   3   4   5   6   7
		 *   |---|---|---|---|---|---|---|---|
		 * 1 |   |   |   |   |   |   |   |   |
		 *   |---|---|---|---|---|---|---|---|
		 * 2 |   |   |   |   |   |   |   |   |
		 *   |---|---|---|---|---|---|---|---|
		 * 3 |   |   |   |   |   |   |   |   |
		 *   |---|---|---|---|---|---|---|---|
		 * 
		 * 
		 * Will return in the format of : [row,col]. Example [1,2]
		 */

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

		if (pos.x < -7.5f) {
			col = 0;
		} else if (pos.x < -3.25f && pos.x >= -7.5f) {
			col = 1;
		} else if (pos.x < -0.9f && pos.x >= -3.25f) {
			col = 2;
		} else if (pos.x < 1.1f && pos.x >= -0.9f) {
			col = 3;
		} else if (pos.x < 3.3f && pos.x >= 1.1f) {
			col = 4;
		} else if (pos.x < 7.5f && pos.x >= 3.3f) {
			col = 5;
		} else if (pos.x >= 7.5f) {
			col = 6;
		}

		return "[" + row + "," + col + "]";
	}
}
