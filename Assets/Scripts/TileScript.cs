using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	public TreeSci treeObject;
	public bool occupied;

	public GameControl gameControl;

	void OnMouseDown()
	{
		Debug.Log("Tile Pressed");
		if (GameControl.canSpawnTree)
		{
			GameControl.canSpawnTree = false;

			GameControl.coinValue -= 100;

			gameControl.SpawnTree(transform.position);

			occupied = true;
		}
	}

}
