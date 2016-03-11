using UnityEngine;
using System.Collections;

public class EnemyFlame : MonoBehaviour {

	public Enemy flameEnemy;

	void Start()
	{
		flameEnemy = GetComponent<Enemy>();
	}

	void Update()
	{
		if (flameEnemy.touchedTree)
		{
			flameEnemy.moveable = false;           
			Invoke("StopMovement",1f);
			flameEnemy.faceDirectionRight = !flameEnemy.faceDirectionRight;
			flameEnemy.touchedTree = !flameEnemy.touchedTree;
		}
	}

	public void FlipMovement()
	{
		// Multiply scale by -1 so that the sprite will be flipped
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

		flameEnemy.movementSpeed = 3f;
	}

	public void StopMovement()
	{
		flameEnemy.moveable = true;
		FlipMovement();

	}
}
