using UnityEngine;
using System.Collections;

public class TreeScript2 : MonoBehaviour {

	public float health;
	public float timer;
	public float defaultTimer = 4f;

	public Coin m_coin;

	public UIScript uiActivation;

	public void Start() 
	{
		health = 100f;
		timer = defaultTimer;
	}

	public void Update()
	{
		if (timer <= 0f)
		{
			InstantiateCoin();
			timer = defaultTimer;
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
		Instantiate(m_coin,newLocation,Quaternion.identity);

	}

	public void HealTree(float healPoint) 
	{
		health += healPoint;

		if (health > 100f) 
		{
			health = 100f;
		}
	}

	public void DamageTree(float damagePoint)
	{
		health -= damagePoint;
		if (health <= 0f)
		{
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
			uiActivation.transform.position = new Vector3(Input.mousePosition.x,Input.mousePosition.y ,0f);
			uiActivation.ShowTreeUI();
		}

		// if left click on the tree
		if (Input.GetMouseButtonDown(1))
		{
			uiActivation.HideUI();
		}
	}
}
