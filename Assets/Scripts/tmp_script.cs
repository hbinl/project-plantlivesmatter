using UnityEngine;
using System.Collections;

public class tmp_script : MonoBehaviour {

    public float timer;


    // Use this for initialization
    void Start () {
        timer = 4f;
	}
	
	// Update is called once per frame
	void Update () {
        if (timer <= 0f)
        {
            Application.LoadLevel("GameScene");
        }
        else
        {
            timer -= Time.deltaTime;
        }

    }
}
