using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroSceneButton : MonoBehaviour {

	public void onClickPlay()
	{
		SceneManager.LoadScene("GameScene");
	}

	public void onClickLogout()
	{
		SceneManager.LoadScene ("LoginScene");
	}
    
    public void onClickLoadStore() 
    {
        SceneManager.LoadScene("GameStoreScene");
    }
    
    public void onClickLoadHighScore() 
    {
        SceneManager.LoadScene("HighScoreScene");
    }
    
    public void onClickLoadWorldTree() 
    {
        SceneManager.LoadScene("WorldTreeScene");
    }
    
    public void onClickLoadHome() {
        SceneManager.LoadScene("IntroScene");
    }
}
