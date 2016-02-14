using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {
    public List<List<Tree>> treeGrid = new List<List<Tree>>();
    public List<Tree> row0 = new List<Tree>();
    public List<Tree> row1 = new List<Tree>();
    public List<Tree> row2 = new List<Tree>();

    private double polRate;

	void Start()
    {
        CreateFullTrees();
    }

	// Update is called once per frame
	void FixedUpdate () {
	    for (int i = 0 ; i <= 3; i++)
        {
            for (int j = 0; j <= 5; j++)
            {
                polRate = treeGrid[i][j].UpdatePolRate();
            }
        }
	}

    void CreateFullTrees()
    {
        treeGrid.Add(row0);
        treeGrid.Add(row1);
        treeGrid.Add(row2);
    }
}
