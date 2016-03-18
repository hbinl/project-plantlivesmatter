using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		// if enemy touch the collider, then destroy it
		// located at the left and right of the screen
		if (col.gameObject.tag == "Enemy")
		{
			col.GetComponent<Enemy>().DestroyEnemy();
		}


		// if coin touch the collider, then destroy it
		// located on the top corner right
        if (col.gameObject.tag == "Coin")
        {
            Debug.Log("Coin collected");
            col.GetComponent<Coin>().DestroyCoin();
        }
	}


}
