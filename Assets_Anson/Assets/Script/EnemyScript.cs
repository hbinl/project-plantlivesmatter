using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float health;
	public bool faceDirectionRight;

	public bool moveable;
	public float movementSpeed;
	public float damageDealt;

	public UIScript uiActivation;

	public void Start() 
	{
		health = 100f;
		// faceDirectionRight TURN OFF FOR TESTING ONLY	
		//faceDirectionRight = false;

		damageDealt = 1f;

		moveable = true;
		movementSpeed = 2f;

		if (faceDirectionRight)
		{
			// Multiply scale by -1 so that the sprite will be flipped
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	public void Update()
	{
		if (moveable)
		{
			Move(faceDirectionRight);
		}
	}

	public void Move(bool faceDirectionRight)
	{
		Vector2 start, end;

		if (faceDirectionRight)
		{
			start = new Vector2(transform.position.x + .7f, transform.position.y);
			end = new Vector2(transform.position.x + .8f,transform.position.y);
		}
		else
		{
			start = new Vector2(transform.position.x - .7f, transform.position.y);
			end = new Vector2(transform.position.x - .8f,transform.position.y);
		}
		RaycastHit2D hit = Physics2D.Linecast(start,end);

		//Draw the line
		Debug.DrawLine(start, end,Color.blue);

		// to check if the enemy hit something to the LEFT
		if (hit.transform != null)
		{
			if (hit.transform.gameObject.tag == "Tree")
			{
				hit.transform.GetComponent<TreeScript>().DamageTree(damageDealt);
			}
			else
			{
				if (faceDirectionRight)
					transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
				else
					transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
			}
		}
		else
		{
			if (faceDirectionRight)
				transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
			else
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
		//Destroy enemy object, add sound and animation

		//if the UI is still pointing to this object and it will be destroy
		// then the UI also need to be disabled
		if (this.gameObject == GameControl.selectedObject)
			uiActivation.HideUI();

		Destroy(this.gameObject);
	}

	public void OnMouseOver()
	{
		// if right click to the enemy and not clicking any ui object
		if (Input.GetMouseButtonDown(0) && !UIUtilities.isCursorOnUI())
		{
			Debug.Log("Enemy Clicked");
		}

		// if right click on the tree and is not clicking any UI
		if (Input.GetMouseButtonDown(0) && !UIUtilities.isCursorOnUI())
		{
			GameControl.selectedObject = this.gameObject;
			uiActivation.transform.position = new Vector3(Input.mousePosition.x,Input.mousePosition.y ,0f);
			uiActivation.ShowEnemyUI();
		}

		// if left click on the tree
		if (Input.GetMouseButtonDown(1))
		{
			uiActivation.HideUI();
		}
	}

}
