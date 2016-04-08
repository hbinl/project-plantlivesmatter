using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour {
    
    public Texture2D blackScreen;
    public float fadeInTime;
    public float fadeOutTime;
    
    private bool fadeIn = true;
    private Color color = Color.black;  
    private float timer = 0;
    
	// Use this for initialization
	void Start () {
       if (blackScreen == null) {
           blackScreen = new Texture2D(Screen.width, Screen.height, TextureFormat.ARGB32, false);
       }
       
	   FadeIn();
	}
	
	// Update is called once per frame
	void Update () {
	   timer -= Time.deltaTime;
       if (timer <= 0) {
           timer = 0;
       }
	}
    
    void OnGUI() {
        if (fadeIn) {
            color.a = timer / fadeInTime;
        } else {
            color.a = 1 - ((timer/fadeOutTime));
        }
        
        GUI.color = color;
        GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), blackScreen);
    }
    
    public void FadeIn() {
        timer = fadeInTime;
        fadeIn = true;
    }
    
    public void FadeOut() {
        timer = fadeOutTime;
        fadeIn = false;
 
        
    }
    
    public void LoadNextLevel(string scene)
    {
        StartCoroutine(LevelLoad(scene));
    }

    IEnumerator LevelLoad(string scene)
    {
        yield return new WaitForSeconds(fadeOutTime+0.1f);
        SceneManager.LoadScene(scene);
    }
}
