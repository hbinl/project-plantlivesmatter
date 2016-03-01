using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreeSci : MonoBehaviour {
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

    private float co2Rate;

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
    }

    public float ReducePolRate()
    {
        return co2Rate;
    }

    public void OnMouseDown()
    {
        Debug.Log("Click");
        Destroy(this.gameObject);
    }
}
