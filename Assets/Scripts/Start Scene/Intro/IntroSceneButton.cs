using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroSceneButton : MonoBehaviour {
    public GameObject loading;

    void Start()
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
        SceneManager.LoadScene ("GameScene");
    }
}
