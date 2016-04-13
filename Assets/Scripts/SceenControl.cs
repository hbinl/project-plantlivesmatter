using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceenControl : MonoBehaviour {

    public void onClickGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void onClickLogout()
    {
        SceneManager.LoadScene("LoginScene");
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

    public void onClickLoadHome()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void onClickLoadTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}
