using UnityEngine;
using System.Collections;

using System.IO;
using System;

public class Testing : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		string textInfo = "";
		textInfo = "***** Start Testing *****" + "\n";
		textInfo += Application.persistentDataPath + "\n";
		textInfo += "*****  End  Testing *****" + "\n";

		Debug.Log (textInfo);
	}
	

}
