using UnityEngine;
using System.Collections;

public class WorldTreeInfo : MonoBehaviour {

	// Use this for initialization
	public void clickInfo() {
        if (this.gameObject.active)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
	
	}

}
