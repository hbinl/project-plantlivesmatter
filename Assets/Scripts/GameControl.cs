using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {
    public List<List<TreeSci>> treeGrid = new List<List<TreeSci>>();
    public List<TreeSci> row0 = new List<TreeSci>();
    
   // private float polRate;
    private int counter = 0;
    public static meterController meterCon;
    public TreeSci tree;
    public Enemy villain;
    public bool alive;
    public Enemy villainObj;

    public static float Co2Value;
    public static float polRate;

    void Start()
    {
        Co2Value = 0.5f;
        polRate = 50;

        CreateFullTrees();
        alive = true;
        CreateEnemy();
    }

	// Update is called once per frame
	void Update () {

	    for (int i = 0 ; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
               // polRate = treeGrid[i][j].ReducePolRate();
              //  meterCon.UpdatePolRate(polRate);
            }
        }
        if (villainObj.transform.position.x < -10.0f)
        {
            alive = false;
            counter -= 1;
            villainObj.DestroyEnemy();
            Debug.Log("LOL");
        }
        if (alive)
        {
            CreateEnemy();
            Debug.Log("LALA");
        }
    }

    public void CreateEnemy()
    {
        float spawnPosX = 11.0f;
        float spawnPosY = Random.Range(1.5f, -2);
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, -1.0f);
        villainObj = Instantiate(villain, spawnPos, Quaternion.identity) as Enemy;
        counter += 1;
        alive = true;
    }

    void CreateFullTrees()
    {
        float x_pos_offset = -3.5f;
        float y_pos_offset = 2f;
        float x_gap = 1.7f;
        float x_pos = x_pos_offset;
        float y_pos = y_pos_offset;
        for (int i = 0; i < 3; i++)
        {
            row0.Clear();
            for (int j = 0; j < 5; j++)
            {
                TreeSci anObj;
                anObj = Instantiate(tree, new Vector3(x_pos, y_pos, (i * -1)), Quaternion.identity) as TreeSci;
                row0.Add(anObj);
                x_pos += x_gap;
            }
            List<TreeSci> row = new List<TreeSci>(row0);
            treeGrid.Add(row);
            x_pos = x_pos_offset - ((i+1) * 0.4f);
            x_gap += 0.25f;
            y_pos = y_pos_offset - ((i+1) * 1.7f);
        }
    }

    //public void RemoveTree(TreeSci selectedTree)
    //{
    //    treeGrid.Remove(selectedTree);
    //}
    
    public static void UpdatePolRate(float newPolRate)
    {
        polRate -= newPolRate;
        meterCon.meterPointer.value -= newPolRate / 100;
    }
}
