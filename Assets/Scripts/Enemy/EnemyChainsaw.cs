using UnityEngine;
using System.Collections;

public class EnemyChainsaw : MonoBehaviour {

	public Enemy chainsawEnemy;

	private Animator animator;

	// Use this for initialization
	void Start () {
		chainsawEnemy = GetComponent<Enemy>();

		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		hitTree();
	}

	public void hitTree()
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

				// to hit the tree
				hit.transform.GetComponent<TreeSci>().DamageTree(1f);
			}
			else
			{
				animator.SetBool("damageTree", false);
			}
		}
		else
		{
			animator.SetBool("damageTree", false);
		}
	}
}
