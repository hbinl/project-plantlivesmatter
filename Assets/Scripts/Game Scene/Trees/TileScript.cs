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
		if (GameControl.coinValue >= 100 && !occupied && GameControl.treeButtonUI && !GameControl.wavesEnded && Time.timeScale == 1) 
		{
			GameControl.coinValue -= 100;

			treeObject = gameControl.SpawnTree(transform.position);
			occupied = true;

			// add tree plant to the user data
			UserInGameProgress.treePlanted += 1;

			// tracking
			UserMovementTracker.TreeTrack(transform.position,"P");
		}
	}

}
