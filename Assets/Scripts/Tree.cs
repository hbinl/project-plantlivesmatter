using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tree : MonoBehaviour {
    private string stage;

    public string ini_stage
    {
        get { return stage; }
        set { stage = value; }
    }

    private string status;

    public string ini_status
    {
        get { return status; }
        set { status = value; }
    }

    private double hp;
    public Text hp_text;

    public double ini_hp
    {
        get { return hp; }
        set { hp = value; }
    }

    private int goldNum;

    public int ini_goldNum
    {
        get { return goldNum; }
        set { goldNum = value; }
    }

    private double co2Rate;

    public double ini_co2Rate
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
    }

    public double UpdatePolRate()
    {
        return co2Rate;
    }
}
