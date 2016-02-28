using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health;
	public bool faceDirectionRight;

	public bool moveable;
	public float movementSpeed;

	public void Start() 
	{
		health = 100f;
		faceDirectionRight = true;

		moveable = true;
		movementSpeed = 2f;
	}

	public void Update()
	{
		Move();
	}

	public void Move()
	{
		Vector2 start = new Vector2(transform.position.x - .7f, transform.position.y);
		Vector2 end = new Vector2(transform.position.x - .8f,transform.position.y);
		RaycastHit2D hit = Physics2D.Linecast(start,end);
		if (hit.transform != null)
		{
			if (hit.transform.gameObject.tag == "Tree")
			{
				hit.transform.GetComponent<TreeScript>().DamageTree(1f);
			}
			else
			{
				transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
			}
		}
		else
		{
			transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
		}
	}

	public void DamageEnemy(float damagePoint) 
	{
		health -= damagePoint;
		if (health <= 0f)
		{
			DestroyEnemy();
		}
	}

	public void DestroyEnemy() 
	{
		//Destroy tree object, add sound and animation
		Destroy(this.gameObject);
	}

	public void OnMouseDown()
	{
		Debug.Log("Enemy Clicked");
	}

}
