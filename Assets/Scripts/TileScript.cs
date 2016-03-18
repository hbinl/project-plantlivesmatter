using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	public TreeSci treeObject;
	public bool occupied;

	public GameControl gameControl;

	void Start()
	{
		if (treeObject == null)
		{
			occupied = false;
		}
		else
		{
			occupied = true;
		}
	}

    void Update()
    {
		// check whether the treeObject is available or not
        if (treeObject == null)
        {
            occupied = false;
        }
    }

	void OnMouseDown() // Mouse Over
	{
		// if the the player can spawn the tree and the place is occupied or not
		if (GameControl.canSpawnTree && !occupied) 
		{
			GameControl.canSpawnTree = false;

			GameControl.coinValue -= 100;

			treeObject = gameControl.SpawnTree(transform.position);
			occupied = true;
		}
	}

}
