using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroSceneButton : MonoBehaviour {
    public GameObject loading;
    public GameObject chainsaw;

    void Awake()
    {
        loading.SetActive(false);
    }

	public void onClickPlay()
	{
        if (UserDataInGame.userData.boughtItem_1 != 0)
        {
            ItemSlot.christmasPack = true;
        }
        else
        {
            ItemSlot.christmasPack = false;
        }

        if (UserDataInGame.userData.boughtItem_2 != 0)
        {
            ItemSlot.boostCoin = true;
        }
        else
        {
            ItemSlot.boostCoin = false;
        }

        if (UserDataInGame.userData.boughtItem_3 != 0)
        {
            ItemSlot.boostSuePaper = true;
        }
        else
        {
            ItemSlot.boostSuePaper = false;
        }
        loading.SetActive(true);
        chainsaw.GetComponent<Animator>().SetBool("damageTree", false);
        Debug.Log("FUCK MASTER PRO");
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
    
    public void onClickLoadTutorial() {
        SceneManager.LoadScene("TutorialScene");
    }
}
