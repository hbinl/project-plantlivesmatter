using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverControl : MonoBehaviour {
    public Text highScoreText;
    public Text timerText;
    public Text coinText;
    public Text wavesText;

    void Update()
    {
        highScoreText.text = "HighScore: " + GameControl.highScore;
        coinText.text = "Coins: " + GameControl.coinValue;
        wavesText.text = "Waves Survived: " + GameControl.waveNumber;
    }

    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(GameControl.timer / 60F);
        int seconds = Mathf.FloorToInt(GameControl.timer - minutes * 60);
        timerText.text = string.Format("Timer: {0:0}:{1:00}", minutes, seconds);
    }

    public void OnRestartButton()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
