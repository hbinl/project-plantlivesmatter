using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreeSci : MonoBehaviour {
    public float timer;
    public float defaultTimer = 4f;
    public Coin m_coin;
    private double hp;
    private float co2Rate;
    private string status;
    private string stage;
    private int goldNum;

    public meterController meterCon;

    public string ini_stage
    {
        get { return stage; }
        set { stage = value; }
    }

    public string ini_status
    {
        get { return status; }
        set { status = value; }
    }

    public double ini_hp
    {
        get { return hp; }
        set { hp = value; }
    }


    public int ini_goldNum
    {
        get { return goldNum; }
        set { goldNum = value; }
    }


    public float ini_co2Rate
    {
        get { return co2Rate; }
        set { co2Rate = value; }
    }

    void Start()
    {
        hp = 100f;
        stage = "Adult";
        status = "Healthy";
        co2Rate = 0.001f;
        timer = defaultTimer;
    }

    public void Update()
    {
        if (timer <= 0f)
        {
            InstantiateCoin();
            timer = defaultTimer;
            GameControl.UpdatePolRate(.1f);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void InstantiateCoin()
    {
        //Instantiate Coin
        Vector3 newLocation = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z - 1f);
        Instantiate(m_coin, newLocation, Quaternion.identity);

    }

    public float ReducePolRate()
    {
        return co2Rate;
    }

    public void DamageTree(float damagePoint)
    {
        hp -= damagePoint;
        if (hp <= 0f)
        {
            DestroyTree();
        }
    }

    public void DestroyTree()
    {
        //Destroy tree object, add sound and animation
        Destroy(this.gameObject);
    }
}
