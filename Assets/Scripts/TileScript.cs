using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	public TreeSci treeObject;
	public bool occupied;

	public GameControl gameControl;

    void Update()
    {
        if (treeObject == null)
        {
            occupied = false;
        }
    }

	void OnMouseDown() // Mouse Over
	{
		Debug.Log("Tile Pressed");
		if (GameControl.canSpawnTree && !occupied) //if Leftclick released && canSpawnTree
		{
			GameControl.canSpawnTree = false;

			GameControl.coinValue -= 100;

			gameControl.SpawnTree(transform.position);
			occupied = true;
		}
	}

}
