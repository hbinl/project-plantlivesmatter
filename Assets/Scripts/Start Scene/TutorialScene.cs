using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour {
    
    public GameObject screen;
    public static int pageIndex = 0;
    private int pageLimit = 11;

    public void nextPage() {
        if (pageIndex < pageLimit-1) {
            pageIndex++;
            loadTutorialPage();
            // Debug.Log(pageIndex);
        } else {
            onClickLoadHome();
        }
    }
    
    public void prevPage() {
        if (pageIndex <= 0) {
            onClickLoadHome();
        } else {
            pageIndex--;
            loadTutorialPage();
            // Debug.Log(pageIndex);
        }
    }
    
    public void loadTutorialPage() {
        string path = "Tutorial/p" + pageIndex;
        screen.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
    }
    
    public void onClickLoadHome() {
        pageIndex = 0;
        SceneManager.LoadScene("IntroScene");
    }
}
