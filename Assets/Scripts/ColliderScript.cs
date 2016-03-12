using UnityEngine;
using System.Collections;

public class ColliderScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
	{
		// if there is a special condition for the object (enemy)
		// before destroyed, then it must be written here
		// before the Destroy line

		Debug.Log("TEST");
		if (col.gameObject.tag == "Enemy")
		{
			Destroy(col.gameObject);
		}
	}


}
