using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour {
    public GameObject pause;
    public GameObject start;
    public GameObject blur;

    private bool onPlay;
	// Use this for initialization
	void Awake () {
        onPlay = true;
        pause.SetActive(true);
        start.SetActive(false);
        blur.SetActive(false);
	}
	
	// Update is called once per frame
	public void StartsButtonClick () {
        onPlay = !onPlay;
        if (onPlay)
        {
            Time.timeScale = 1;
            start.SetActive(false);
            pause.SetActive(true);
            blur.SetActive(false);
        }
	}

    public void PauseButtonClick()
    {
        onPlay = !onPlay;
        if (!onPlay)
        {
            Time.timeScale = 0;
            start.SetActive(true);
            pause.SetActive(false);
            blur.SetActive(true);
        }
    }
}
