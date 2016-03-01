using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {
    public List<List<TreeSci>> treeGrid = new List<List<TreeSci>>();
    public List<TreeSci> row0 = new List<TreeSci>();

    private float polRate;
    public meterController meterCon;
    public TreeSci tree;

	void Start()
    {
        CreateFullTrees();
    }

	// Update is called once per frame
	void FixedUpdate () {
	    for (int i = 0 ; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                polRate = treeGrid[i][j].ReducePolRate();
                meterCon.UpdatePolRate(polRate);
            }
        }
	}

    void CreateFullTrees()
    {
        float x_pos_offset = -4.5f;
        float y_pos_offset = 2.4f;
        float x_pos = x_pos_offset;
        float y_pos = y_pos_offset;
        for (int i = 1; i <= 3; i++)
        {
            row0.Clear();
            for (int j = 1; j <= 5; j++)
            {
                TreeSci anObj;
                anObj = Instantiate(tree, new Vector3(x_pos, y_pos, i * -1), Quaternion.identity) as TreeSci;
                row0.Add(anObj);
                x_pos = x_pos_offset + (j * 2.4f);
            }
            List<TreeSci> row = new List<TreeSci>(row0);
            treeGrid.Add(row);
            x_pos = x_pos_offset - (i * 0.4f);
            y_pos = y_pos_offset - (i * 2.0f);
        }
    }
}
