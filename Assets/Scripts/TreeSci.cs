using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TreeSci : MonoBehaviour {

    public float aSecond;
    public float defaultTimer;
    public Coin m_coin;
    private UIScript uiActivation;
    public float hp;
    private string status;
    private string stage;
    private int goldNum;
    private Animator animator;

	public bool onFire;

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

    public float ini_hp
    {
        get { return hp; }
        set { hp = value; }
    }


    public int ini_goldNum
    {
        get { return goldNum; }
        set { goldNum = value; }
    }

    void Awake()
    {
        hp = 100f;
        stage = "Adult";
        status = "Healthy";

        aSecond = 1.0f;
        defaultTimer = Random.Range(5f, 7f);
        animator = GetComponent<Animator>();
        uiActivation = GameObject.Find("UI_Position").GetComponent<UIScript>();
    }

    public void Update()
    {
		// instantiate the coin after certain time
        if (defaultTimer <= 0f)
        {
            InstantiateCoin();
            defaultTimer = Random.Range(5f, 7f);
        }
        else
        {
            defaultTimer -= Time.deltaTime;
        }

		// to burn the fire every second
        if (aSecond <= 0)
        {
			if (onFire)
			{
				onFireEffect();
			}
            GameControl.polRate -= 0.05f;
            aSecond = 1.0f;
        }
        else
        {
            aSecond -= Time.deltaTime;
        }


    }

    public void InstantiateCoin()
    {
        //Instantiate Coin
        Vector3 newLocation = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z - 1f);
        Instantiate(m_coin, newLocation, Quaternion.identity);

    }

    public void DamageTree(float damagePoint)
    {
        hp -= damagePoint;
        if (hp <= 0f)
        {
            GetComponent<BoxCollider2D>().enabled = false;
			if (onFire)
			{
				animator.SetTrigger("treeBurnt");
			}
			else
			{
				animator.SetTrigger("treeFall");
			}
			StartCoroutine("Fade");
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

        Destroy(this.gameObject,2f);
    }

    public void OnMouseOver()
    {
        // if right click on the tree and is not clicking any UI
        if (Input.GetMouseButtonDown(0) && !UIUtilities.isCursorOnUI())
        {
            GameControl.selectedObject = this.gameObject;
			uiActivation.transform.position = new Vector3(transform.position.x, transform.position.y, 100f);
            uiActivation.ShowTreeUI();
        }

        // if left click on the tree
        if (Input.GetMouseButtonDown(1))
        {
            uiActivation.HideUI();
        }
    }

	public void onFireEffect()
	{
		DamageTree(10f);
	}

	// for fading out when it is death
	IEnumerator Fade() {
		for (float f = 1f; f >= 0; f -= 0.1f) {
			Color c = GetComponent<SpriteRenderer>().material.color;
			c.a = f;
			GetComponent<SpriteRenderer>().material.color = c;
			yield return new WaitForSeconds(.2f);
		}
	}
}
