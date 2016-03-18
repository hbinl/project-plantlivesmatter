using UnityEngine;
using System.Collections;

public class SpawnTreeUI : MonoBehaviour {

	void OnMouseDown()
	{
		// if the game is not ended
		if (!GameControl.wavesEnded)
		{
			// if player has enough money
			if (GameControl.coinValue >= 100)
			{
				GameControl.canSpawnTree = true;
			}
		}
	}
}
