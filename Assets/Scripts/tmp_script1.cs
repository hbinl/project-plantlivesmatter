using UnityEngine;
using System.Collections;

public class tmp_script1 : MonoBehaviour {

    public float timer;
    public Enemy anEnemy;
    public Enemy anyObj;

    public int counter;
    public GameObject slider;
    public GameObject gameOver;

    // Use this for initialization
    void Start () {
        timer = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (timer <= 0f)
        {
            timer = 100f;
            Vector3 enemyPos = new Vector3(11.0f, 1.2f, 1.0f);
            anyObj = Instantiate(anEnemy, enemyPos, Quaternion.identity) as Enemy;
            anyObj.gameObject.SetActive(true);
        }
        else
        {
            timer -= Time.deltaTime;
            if ( timer <= 88f && timer > 72f)
            {
                Debug.Log("HERE");
                anyObj.gameObject.SetActive(false);
                GameControl.suePapers = 0;
            }
            if (timer <= 80f && timer > 63f && counter != 3)
            {
                Vector3 enemyPos = new Vector3(11.0f, 1.2f - (1.4f * counter), -1.0f*counter);
                Instantiate(anEnemy, enemyPos, Quaternion.identity);
                counter++;
            }
            if (timer <= 70f && timer >= 45f)
            {
                GameControl.polRate += 0.03f;
                if (GameControl.polRate > 99f)
                {
                    GameControl.timerActive = false;
                    slider.SetActive(false);
                    gameOver.SetActive(true);
                }
            }
        }
    }
}
