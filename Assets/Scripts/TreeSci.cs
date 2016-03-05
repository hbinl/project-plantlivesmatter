using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreeSci : MonoBehaviour {

    public float timer;
    public float defaultTimer = 4f;
    public Coin m_coin;
    private UIScript uiActivation;
    public double hp;
    private float co2Rate;
    private string status;
    private string stage;
    private int goldNum;
    private Animator animator;

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
        animator = GetComponent<Animator>();
        uiActivation = GameObject.Find("UI_Position").GetComponent<UIScript>();
    }

    public void Update()
    {
        if (timer <= 0f)
        {
            InstantiateCoin();
            timer = defaultTimer;
            GameControl.UpdatePolRate(0.1f);
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
        animator.SetTrigger("treeFire");
        if (hp <= 0f)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            animator.SetTrigger("treeBurnt");
            DestroyTree();
        }
    }

    public void DestroyTree()
    {
        //Destroy tree object, add sound and animation

        //if the UI is still pointing to this object and it will be destroy
        // then the UI also need to be disabled
        if (this.gameObject == GameControl.selectedObject)
            uiActivation.HideUI();

        Destroy(this.gameObject);
    }

    public void OnMouseOver()
    {
        // if right click on the tree and is not clicking any UI
        if (Input.GetMouseButtonDown(0) && !UIUtilities.isCursorOnUI())
        {
            GameControl.selectedObject = this.gameObject;
            uiActivation.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
            uiActivation.ShowTreeUI();
        }

        // if left click on the tree
        if (Input.GetMouseButtonDown(1))
        {
            uiActivation.HideUI();
        }
    }
}
