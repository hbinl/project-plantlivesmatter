using UnityEngine;
using System.Collections;

public class SurrenderControl : MonoBehaviour {
    public static bool surrender;
    public GameControl gameCon;

	// Use this for initialization
	void Start () {
        surrender = false;
	}
	
	public void ClickSurrender()
    {
        surrender = true;
        gameCon.TriggerGameOver();
    }
}
