using UnityEngine;
using System.Collections;

public class TreeScript : MonoBehaviour {

	public float health;
	public float timer;
	public float defaultTimer = 4f;

	public Coin m_coin;

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
		Destroy(this.gameObject);
	}
}
