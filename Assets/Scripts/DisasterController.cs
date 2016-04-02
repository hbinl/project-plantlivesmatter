using UnityEngine;
using System.Collections;

public class DisasterController : MonoBehaviour {
    public bool lightningEffect;
    public bool repeat;
    public bool hazeEffect;

    public ParticleSystem lightning;
    public ParticleSystem haze;

    public float lightningTimer;
    public float hazeTimer;

    public GameControl gameCon;
   
	// Use this for initialization
	void Awake () {
        lightningEffect = false;
        hazeEffect = false;
        repeat = false;
        lightningTimer = 30f;
        hazeTimer = 60f;

        lightning.gameObject.SetActive(false);

        haze.gameObject.SetActive(false);
        haze.Stop();  
	}

    // Update is called once per frame
    void Update ()
    {
        if (lightningEffect)
        {
            if (lightningTimer >= 0 && repeat)
            {
                lightningEffect = false;
                StartCoroutine(lightningFire());
            }
        }
        else
        {
            if (lightningTimer <= 0)
            {
                lightning.Stop();
                repeat = false;
            }
            else
            {
                lightningTimer -= Time.deltaTime;
                repeat = true;
            }
        }

        if (hazeEffect)
        {
            if (hazeTimer <= 0)
            {
                hazeEffect = false;
                hazeTimer = 60f;
                haze.Stop();                                
            }
            else
            {
                hazeTimer -= Time.deltaTime;
            }
        }
    }

    public void activateLightning()
    {
        lightning.gameObject.SetActive(true);
        lightning.Play();
        lightningTimer = 60f; 
		repeat = true;
    }

    public void activateHaze()
    {
        haze.gameObject.SetActive(true);
        haze.Play();
    }

    IEnumerator lightningFire()
    {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < 3; i++)
        {
            if (gameCon.treeGrid.Count > 0)
            {
                int rand_tree_index = Random.Range(0, gameCon.treeGrid.Count);
                if (!gameCon.treeGrid[rand_tree_index].onFire)
                {
                    gameCon.treeGrid[rand_tree_index].onFire = true;
                }
            }
        }
        lightningEffect = true;
    }

    
}
