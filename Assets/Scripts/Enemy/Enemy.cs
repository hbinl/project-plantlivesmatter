using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health;
	public bool faceDirectionRight = false;

	public bool moveable;
    public bool alive;
	public float movementSpeed;
    public float damageDealt;

	public bool enemyIsActive;

    private Animator animator;

	public bool touchedTree;

    public void Start() 
	{
		touchedTree = false;
        health = 100f;
        damageDealt = 0.1f;
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
        if (this.transform.position.x < -11f || this.transform.position.x > 11f)
            selfDestruct();
        animator = this.GetComponent<Animator>();
    }


    //    public void Move(bool faceDirectionRight)
    //    {
    //        Vector2 start, end;

    //        if (faceDirectionRight)
    //        {
    //            start = new Vector2(transform.position.x + .7f, transform.position.y);
    //            end = new Vector2(transform.position.x + .8f, transform.position.y);
    //        }
    //        else
    //        {
    //            start = new Vector2(transform.position.x - .8f, transform.position.y);
    //            end = new Vector2(transform.position.x - .9f, transform.position.y);
    //        }
    //        RaycastHit2D hit = Physics2D.Linecast(start, end);

    //        //Draw the line
    //		Debug.DrawLine(start, end, Color.yellow);

    //        // to check if the enemy hit something to the LEFT
    //        if (hit.transform != null)
    //        {
    //            if (hit.transform.gameObject.tag == "Tree" && enemyIsActive)
    //            {
    ////                animator.SetBool("damageTree", true);
    ////                hit.transform.GetComponent<TreeSci>().DamageTree(damageDealt);
    //				touchedTree = true;
    //            }
    //            else
    //            {
    ////                animator.SetBool("damageTree", false);
    //                if (faceDirectionRight)
    //                    transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    //                else
    //                    transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    //            }
    //        }
    //        else
    //        {
    ////            animator.SetBool("damageTree", false);
    //            if (faceDirectionRight)
    //                transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    //            else
    //                transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    //        }
    //    }

    IEnumerator Fade()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Color c = GetComponent<SpriteRenderer>().material.color;
            c.a = f;
            GetComponent<SpriteRenderer>().material.color = c;
            yield return new WaitForSeconds(.2f);
        }
    }

    public void DamageEnemy(float damagePoint,float bonusPoints) 
	{
		health -= damagePoint;
		if (health <= 0f)
        {
            GameControl.enemyNumber -= 1;
            GameControl.enemyKilled += 1;
            GameControl.highScore += bonusPoints;
            DestroyEnemy();
        }
	}

	public void DestroyEnemy() 
	{
        //Destroy tree object, add sound and animation
        //if the UI is still pointing to this object and it will be destroy
        // then the UI also need to be disabled
        this.GetComponent<BoxCollider2D>().enabled = false;
        faceDirectionRight = !this.faceDirectionRight;
        GetCaught();
        StartCoroutine(Fade());
        Destroy(this.gameObject,4f);
	}

    public void selfDestruct()
    {
        Destroy(this.gameObject);
    }


    public void GetCaught()
    {
        animator.SetTrigger("enemyCaught");
    }
//    public void OnMouseOver()
//    {
//        // if right click on the tree and is not clicking any UI
//        if (Input.GetMouseButtonDown(0) && !UIUtilities.isCursorOnUI())
//        {
//            Debug.Log("Enemy Clicked");
//            GameControl.selectedObject = this.gameObject;
//        }
//
//    }
}
