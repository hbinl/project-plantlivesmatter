using UnityEngine;
using System.Collections;

public class Coin2 : MonoBehaviour {

	public float movementSpeed;
	public float timer;
	public float endHeight;

	public void Start() 
	{
		endHeight = transform.position.y - 2f;
		movementSpeed = 1.5f;
		timer = 3f;
	}

	public void Update()
	{
		timer -= Time.deltaTime;
		MoveDownCoin();
	}

	public void MoveDownCoin()
	{
		// move down coin
		if (timer <= 0f)
		{
			DestroyCoin();
		}
		else
		{
			//Debug.Log(transform.position);
			if (transform.position.y > endHeight)
			{
				transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
			}
		}
	}

	public void DestroyCoin()
	{
		//Destroy coin object, add sound and animation if it is not clicked
		Destroy(this.gameObject);
	}

	public void OnMouseOver()
	{
		// if right click to the coin and not clicking any ui object
		if (Input.GetMouseButtonDown(0) && !UIUtilities.isCursorOnUI())
		{
			Debug.Log("Coin Clicked");
			DestroyCoin();
		}
	}
}
