using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStoreController : MonoBehaviour {
    public Text goldLeaf;
	
	// Update is called once per frame
	void Update () {
        goldLeaf.text = UserDataInGame.userData.goldLeaf.ToString();
	}
}
