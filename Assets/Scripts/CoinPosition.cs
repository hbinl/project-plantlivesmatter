using UnityEngine;
using System.Collections;

public class CoinPosition : MonoBehaviour {

    public static GameObject coinMeter;

    void Start()
    {
		// the corner right position reference for the coin collected animation
        coinMeter = this.gameObject;
    }
}
