using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Plant1 : MonoBehaviour
{
    private float health;
    public Text healthText;
    private int happiness;
    private int exp;
    private int numGoldLeafs;
    private float hpDecayRate;
    private float time;
    public Text timerText;
    private bool playing;
    private string stage;

    // Use this for initialization
    void Start()
    {
        health = 25;
        happiness = 100;
        exp = 24;
        numGoldLeafs = 10;
        
        stage = "Sprout";
        playing = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playing)
        {
            time += Time.deltaTime;
        }
        timerText.text = "Time: " + Mathf.RoundToInt(time);

        if (health < 20)
        {
            GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 0.0f, 0.8f);
        }
        else if (health < 10)
        {
            GetComponent<SpriteRenderer>().color = new Color(244f, 164f, 96f, 0.8f);
        }
        else if (health == 0)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }

        if (time % 2 == 0)
        {
            health -= hpDecayRate;
        }
        healthText.text = "Health: " + Mathf.RoundToInt(health);
    }

    float GetHeatlh()
    {
        return health;
    }

    void SetHealth(int NewHealth)
    {
        health = NewHealth;
    }

    int GetHappiness()
    {
        return happiness;
    }

    void SetHappiness(int NewHappiness)
    {
        happiness = NewHappiness;
    }

    int GetExp()
    {
        return exp;
    }

    void SetExp(int NewExp)
    {
        exp = NewExp;
    }
}