using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

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
		lastPost = "[0,0]";
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
		// before start next wave, generate the wave log file
		// try {
		// 	String waveTrackData = GenerateFinaliseTrackData(moveTrack);
		// 	Debug.Log (waveTrackData);
		// } catch (ArgumentOutOfRangeException e) {
		// 	Debug.Log ("ARGUMENT OUT OF RANGE, Current assumption is string too long");
		// }

		trackResult += moveTrack + "\n";
		moveTrack = "";
	}

//	public static void SaveToFile() {
////		Debug.Log (UserDataInGame.userData.username);

//		string nowDateAndTime = Convert.ToString( DateTime.Now.ToOADate());
//		nowDateAndTime = nowDateAndTime.Replace ('.', '_');
//		string path = Application.persistentDataPath + "/m_" + UserDataInGame.userData.username + "_" + nowDateAndTime ;

//		File.Create(path).Dispose();

//		File.WriteAllText (path, trackResult);
//	}

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

	// public static String GenerateFinaliseTrackData(string waveLineText) {
	// 	// Generate each wave file to be sumbit to the server
	// 	// and check if the user is a novice, intermediate or an expert
	// 	List<String> line = new List<String>();
	// 	List<String> final_scores = new List<String>();
	// 	List<List<float>> board_positions = new List<List<float>>();

	// 	line = waveLineText.Split(' ').ToList<String>();

	// 	board_positions.Add(new List<float> { 0,0,0,0,0,0,0 });
	// 	board_positions.Add(new List<float> { 0,0,0,0,0,0,0 });
	// 	board_positions.Add(new List<float> { 0,0,0,0,0,0,0 });

	// 	final_scores = line.GetRange (1, (line.Count - 3));

	// 	foreach (String element in final_scores) {

	// 		List<String> element_split = element.Split(']').ToList();
	// 		String row_column_element = element_split[0];
	// 		float behaviour_data = float.Parse(element_split[1]);

	// 		row_column_element  = row_column_element.Replace("[","");
	// 		List<String> row_col_elem_split = row_column_element.Split (',').ToList ();
	// 		List<int> row_column = row_col_elem_split.ConvertAll (s => Int32.Parse (s));

	// 		int row, col;
	// 		// row does not start from 0
	// 		row = row_column[0] - 1;
	// 		col = row_column[1];

	// 		board_positions[row][col] += (float) Math.Log(behaviour_data);
	// 	}

	// 	String instance_features = "";
	// 	for (int row = 0; row < board_positions.Count; row++) {
	// 		for (int col = 0; col < board_positions[0].Count; col++) {
	// 			instance_features += board_positions[row][col] + ",";
	// 		}
	// 	}

	// 	// clean final score
	// 	String the_score = line[line.Count - 2];
	// 	the_score = the_score.Replace("[","");
	// 	the_score = the_score.Replace("]","");


	// 	List<String> scores = the_score.Split(',').ToList();

	// 	String score_behaviour = scores[1] + "," + scores[2] + "," + scores[3];
	// 	instance_features += score_behaviour;

	// 	Console.WriteLine(instance_features);
	// 	return instance_features;

	// }
}
