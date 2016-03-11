using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverControl : MonoBehaviour {
    public Text timerText;
    public Text coinText;
    public Text highScoreText;

	// Use this for initialization
	void Update () {
        //timerText.text = "Time: " + GameControl.timer.ToString();
        coinText.text = "Coin: " + GameControl.coinValue.ToString();
        highScoreText.text = "Score: " + GameControl.highScore.ToString();
	}
    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(GameControl.timer / 60);
        int seconds = Mathf.FloorToInt(GameControl.timer - minutes / 60);
        timerText.text = string.Format("Time: {0:D2}:{1:D2}", minutes, seconds);
    }
}
