using UnityEngine;
using System.Collections;

public class Bulldozer : MonoBehaviour {

	private Enemy buldozerEnemy;

	private Animator animator;

	public float delayStartMovement;
	public float timer;
    public float killPoints;

	// Use this for initialization
	void Start () {
		buldozerEnemy = GetComponent<Enemy>();
        killPoints = 150f;
		animator = GetComponent<Animator>();

		buldozerEnemy.moveable = false;
		delayStartMovement = 5f;

		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < delayStartMovement)
		{
			timer += Time.deltaTime;
		}
		else
		{
			buldozerEnemy.moveable = true;
			Move();
		}
	}

	public void Move()
	{
		Vector2 start, end;

		if (buldozerEnemy.faceDirectionRight)
		{
			start = new Vector2(transform.position.x + 2.4f, transform.position.y);
			end = new Vector2(transform.position.x + 2.5f, transform.position.y);
		}
		else
		{
			start = new Vector2(transform.position.x - 2.4f, transform.position.y);
			end = new Vector2(transform.position.x - 2.5f, transform.position.y);
		}
		RaycastHit2D hit = Physics2D.Linecast(start, end);

		//Draw the line
		Debug.DrawLine(start, end, Color.blue);

		if (hit.transform != null)
		{
			if (hit.transform.gameObject.tag == "Tree" && buldozerEnemy.enemyIsActive)
			{
				animator.SetBool("damageTree", true);
				buldozerEnemy.touchedTree = true;

				hit.transform.GetComponent<TreeSci>().DamageTree(1000f);
			}
			else
			{
				animator.SetBool("damageTree", false);
                if (buldozerEnemy.faceDirectionRight)
                    transform.Translate(Vector3.right * buldozerEnemy.movementSpeed * Time.deltaTime);
                else
                    transform.Translate(Vector3.left * buldozerEnemy.movementSpeed * Time.deltaTime);
            }
		}
		else
		{
			animator.SetBool("damageTree", false);
            if (buldozerEnemy.faceDirectionRight)
                transform.Translate(Vector3.right * buldozerEnemy.movementSpeed * Time.deltaTime);
            else
                transform.Translate(Vector3.left * buldozerEnemy.movementSpeed * Time.deltaTime);
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
				buldozerEnemy.DamageEnemy(33.4f, killPoints);
			}
		}

	}
}
