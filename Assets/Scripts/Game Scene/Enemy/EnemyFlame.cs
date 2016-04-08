using UnityEngine;
using System.Collections;

public class EnemyFlame : MonoBehaviour {

	private Enemy flameEnemy;

	private Animator animator;
    public float killPoints;

	void Start()
	{
		flameEnemy = GetComponent<Enemy>();
        killPoints = 100f;
		animator = GetComponent<Animator>();
		flameEnemy.moveable = true;
	}

	void Update()
	{
		if (flameEnemy.touchedTree)
		{
			flameEnemy.enemyIsActive = false;

			flameEnemy.moveable = false;
			Invoke("StopMovement",1f);
			flameEnemy.faceDirectionRight = !flameEnemy.faceDirectionRight;
			flameEnemy.touchedTree = !flameEnemy.touchedTree;
		}

		if (flameEnemy.moveable)
        {
            Move();
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

	public void Move()
	{
		Vector2 start, end;

		if (flameEnemy.faceDirectionRight)
		{
			start = new Vector2(transform.position.x + .7f, transform.position.y);
			end = new Vector2(transform.position.x + .8f, transform.position.y);
		}
		else
		{
			start = new Vector2(transform.position.x - .8f, transform.position.y);
			end = new Vector2(transform.position.x - .9f, transform.position.y);
		}
		RaycastHit2D hit = Physics2D.Linecast(start, end);

		//Draw the line
		Debug.DrawLine(start, end, Color.yellow);

		if (hit.transform != null)
		{
			if (hit.transform.gameObject.tag == "Tree" && flameEnemy.enemyIsActive)
			{
				animator.SetBool("damageTree", true);
				flameEnemy.touchedTree = true;

				// to hit the tree
				hit.transform.GetComponent<TreeSci>().onFire = true;
				//hit.transform.GetComponent<Animator>().SetBool("treeFire",true);
			}
			else
			{
				animator.SetBool("damageTree", false);
                if (flameEnemy.faceDirectionRight)
                    transform.Translate(Vector3.right * flameEnemy.movementSpeed * Time.deltaTime);
                else
                    transform.Translate(Vector3.left * flameEnemy.movementSpeed * Time.deltaTime);
            }
		}
		else
		{
			animator.SetBool("damageTree", false);
            if (flameEnemy.faceDirectionRight)
                    transform.Translate(Vector3.right * flameEnemy.movementSpeed * Time.deltaTime);
            else
                    transform.Translate(Vector3.left * flameEnemy.movementSpeed * Time.deltaTime);
        }
    }

	public void OnMouseOver()
	{
		// if right click on the tree and is not clicking any UI
		if (Input.GetMouseButtonDown(0) && !UIUtilities.isCursorOnUI())
		{
			Debug.Log("Enemy Clicked");
			if (GameControl.useSuePaper())
			{
				flameEnemy.DamageEnemy(51f, killPoints);
			}
		}

	}
}
