using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		// if there is a special condition for the object (enemy)
		// before destroyed, then it must be written here
		// before the Destroy line

		if (col.gameObject.tag == "Enemy")
		{
			col.GetComponent<Enemy>().DestroyEnemy();
		}

        if (col.gameObject.tag == "Coin")
        {
            Debug.Log("Coin collected");
            col.GetComponent<Coin>().DestroyCoin();
        }
	}


}
