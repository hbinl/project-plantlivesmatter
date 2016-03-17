using UnityEngine;
using System.Collections;

public class EnemyChainsaw : MonoBehaviour {

	private Enemy chainsawEnemy;

	private Animator animator;
    public float killPoints;

	// Use this for initialization
	void Start () {
		chainsawEnemy = GetComponent<Enemy>();
        killPoints = 50f;
		animator = GetComponent<Animator>();
		chainsawEnemy.moveable = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (chainsawEnemy.moveable)
        {
            Move();
        }
	}

	public void Move()
	{
		Vector2 start, end;

		if (chainsawEnemy.faceDirectionRight)
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
			if (hit.transform.gameObject.tag == "Tree" && chainsawEnemy.enemyIsActive)
			{
				animator.SetBool("damageTree", true);
				chainsawEnemy.touchedTree = true;

				hit.transform.GetComponent<TreeSci>().DamageTree(chainsawEnemy.damageDealt);

//				// to hit the tree
//				hit.transform.GetComponent<TreeSci>().DamageTree(1f);
			}
			else
			{
				animator.SetBool("damageTree", false);
                if (chainsawEnemy.faceDirectionRight)
                    transform.Translate(Vector3.right * chainsawEnemy.movementSpeed * Time.deltaTime);
                else
                    transform.Translate(Vector3.left * chainsawEnemy.movementSpeed * Time.deltaTime);
            }
		}
		else
		{
			animator.SetBool("damageTree", false);
            if (chainsawEnemy.faceDirectionRight)
                transform.Translate(Vector3.right * chainsawEnemy.movementSpeed * Time.deltaTime);
            else
                transform.Translate(Vector3.left * chainsawEnemy.movementSpeed * Time.deltaTime);
        }
	}

	public void OnMouseOver()
	{
		// if right click on the tree and is not clicking any UI
		if (Input.GetMouseButtonDown(0) && !UIUtilities.isCursorOnUI())
		{
			if (GameControl.useSuePaper())
			{
				chainsawEnemy.DamageEnemy(101f, killPoints);
			}
		}

	}
}
