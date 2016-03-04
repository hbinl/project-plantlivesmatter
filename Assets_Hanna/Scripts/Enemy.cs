using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health;
	public bool faceDirectionRight;

	public bool moveable;
	public float movementSpeed;
    public float damagePoint = 0.9f;

    private Animator animator;

	public void Start() 
	{
		health = 100f;
		faceDirectionRight = true;

		moveable = true;
		movementSpeed = 2f;

        
        animator = GetComponent<Animator>();
        
    }

	public void Update()
	{
		Move();
        /*
        if (moveable == true)
        {
            animator.SetBool("damageTree", false);
        }
        else
        {
            animator.SetBool("damageTree", true);
        }
        */
	}

	public void Move()
	{
		Vector2 start = new Vector2(transform.position.x - .9f, transform.position.y);
		Vector2 end = new Vector2(transform.position.x - 1f,transform.position.y);
		RaycastHit2D hit = Physics2D.Linecast(start,end);

        Debug.DrawLine(start, end, Color.black);

		// to check if the enemy hit something to the LEFT
		if (hit.transform != null)
		{
			if (hit.transform.gameObject.tag == "Tree")
			{
                animator.SetBool("damageTree", true);
                
                hit.transform.GetComponent<TreeScript>().DamageTree(damagePoint);
			}
			else
			{
				transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
			}
		}
		else
		{
            animator.SetBool("damageTree", false);
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

	public void OnMouseOver()
	{
		// if right click to the enemy and not clicking any ui object
		if (Input.GetMouseButtonDown(0) && !UIUtilities.isCursorOnUI())
		{
			Debug.Log("Enemy Clicked");
		}
	}

}
