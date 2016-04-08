using UnityEngine;
using System.Collections;

public class UserDataInGame : MonoBehaviour {

	public static UserDataInGame userData;

	// to keep track user data
	public string username;
    //goldleaf
    public int goldLeaf;
	public string achievement;
	public int wave;
	public float time;
	public int treePlanted;
	public int enemyKilled;
	public int treeWatered;
	public int treeHealed;
	public int treeSold;
	public int suePaperPurchased;


	// Use this for initialization
	void Awake () {

		if (userData == null) {
			DontDestroyOnLoad (gameObject);
			userData = this;
		} else if (userData != this) {
			Destroy(gameObject);
		}

	}

}
