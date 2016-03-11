using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health;
	public bool faceDirectionRight = false;
    public bool touchedTree;
    public bool moveable;
    public bool alive;
	public float movementSpeed;
    public float damageDealt;
    private UIScript uiActivation;

    private Animator animator;

    public void Start() 
	{
        touchedTree = false;
        health = 100f;
        damageDealt = 1f;
        moveable = true;
		movementSpeed = 1f;
        if (this.gameObject.transform.position.x < 0)
            faceDirectionRight = true;
        if (faceDirectionRight)
        {
            // Multiply scale by -1 so that the sprite will be flipped
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        animator = GetComponent<Animator>();
        uiActivation = GameObject.Find("UI_Position").GetComponent<UIScript>();
    }

	public void Update()
	{
        if (moveable)
            Move(faceDirectionRight);  
    }

    public void Move(bool faceDirectionRight)
    {
        Vector2 start, end;

        if (faceDirectionRight)
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
        Debug.DrawLine(start, end, Color.blue);

        // to check if the enemy hit something to the LEFT
        if (hit.transform != null)
        {
            if (hit.transform.gameObject.tag == "Tree")
            {
                animator.SetBool("damageTree", true);
                hit.transform.GetComponent<TreeSci>().DamageTree(damageDealt);
            }
            else
            {
                animator.SetBool("damageTree", false);
                if (faceDirectionRight)
                    transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
                else
                    transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
            }
        }
        else
        {
            animator.SetBool("damageTree", false);
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
        //Destroy tree object, add sound and animation
        //if the UI is still pointing to this object and it will be destroy
        // then the UI also need to be disabled
        Destroy(this.gameObject);
	}

    public void OnMouseOver()
    {
        // if right click on the tree and is not clicking any UI
        if (Input.GetMouseButtonDown(0) && !UIUtilities.isCursorOnUI())
        {
            Debug.Log("Enemy Clicked");
            GameControl.selectedObject = this.gameObject;
            uiActivation.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
            uiActivation.ShowEnemyUI();
        }

        // if left click on the tree
        if (Input.GetMouseButtonDown(1))
        {
            uiActivation.HideUI();
        }
    }
}
