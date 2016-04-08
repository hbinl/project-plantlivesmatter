using UnityEngine;
using System.Collections;

public class UserInGameProgress : MonoBehaviour {

	// to keep track user data
	public static int wave;
	public static float time;
	public static int treePlanted; // 
	public static int enemyKilled; //
	public static int treeWatered; //
	public static int treeHealed; //
	public static int treeSold; //
	public static int suePaperPurchased; //

	// Use this for initialization
	void Awake () {
		wave = 0;
		time = 0f;
		treePlanted = 0;
		enemyKilled = 0;
		treeWatered = 0;
		treeHealed = 0;
		treeSold = 0;
		suePaperPurchased = 0;
	}

	// DEBUG PURPOSE ONLY
//	void Update() {
//		string textInfo = "";
//		textInfo = "***** Start Testing *****" + "\n";
//		textInfo += wave + "\n";
//		textInfo += time + "\n";
//		textInfo += treePlanted + "\n";
//		textInfo += enemyKilled + "\n";
//		textInfo += treeWatered + "\n";
//		textInfo += treeHealed + "\n";
//		textInfo += treeSold + "\n";
//		textInfo += suePaperPurchased + "\n";
//		textInfo += "*****  End  Testing *****" + "\n";
//
//		Debug.Log (textInfo);
//	}

}
