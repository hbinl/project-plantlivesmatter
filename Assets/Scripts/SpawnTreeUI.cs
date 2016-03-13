using UnityEngine;
using System.Collections;

public class SpawnTreeUI : MonoBehaviour {

	void OnMouseDown()
	{
		Debug.Log("TREE UI");
		if (GameControl.coinValue >= 100)
		{
			GameControl.canSpawnTree = true;
		}
	}
}
