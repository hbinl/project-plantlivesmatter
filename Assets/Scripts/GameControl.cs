using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {
    public List<List<TreeSci>> treeGrid = new List<List<TreeSci>>();
    public List<TreeSci> row0 = new List<TreeSci>();
    private List<float> spawnPos = new List<float> { 11.0f, 0.0f };

    // private float polRate;
    private int cloneNumber;
    public TreeSci tree;
    public static GameObject selectedObject;
    public Enemy villain;
    public bool alive;
    public meterController meterCon;
    public static float Co2Value;
    public static float polRate;
    public static float highScore;
    public static int coinValue;

    void Start()
    {
        Co2Value = 0.5f;
        polRate = 50;

        CreateFullTrees();
        alive = true;
        cloneNumber = 0;
        CreateRandom(cloneNumber);
        //CreateEnemy();
    }

	// Update is called once per frame
	void Update () {
        meterCon.UpdateMeterPointer(polRate);
    }

    void CreateFullTrees()
    {
        float x_pos_offset = -3.7f;
        float y_pos_offset = 1.2f;
        float x_gap = 1.8f;
        float x_pos = x_pos_offset;
        float y_pos = y_pos_offset;
        for (int i = 0; i < 3; i++)
        {
            row0.Clear();
            for (int j = 0; j < 5; j++)
            {
                TreeSci anObj;
                anObj = Instantiate(tree, new Vector3(x_pos, y_pos, (i * -1)), Quaternion.identity) as TreeSci;
                anObj.gameObject.SetActive(false);
                row0.Add(anObj);
                x_pos += x_gap;
            }
            List<TreeSci> row = new List<TreeSci>(row0);
            treeGrid.Add(row);
            x_pos = x_pos_offset - ((i+1) * 0.4f);
            x_gap += 0.2f;
            y_pos = y_pos_offset - ((i+1) * 1.4f);
        }
    }
    
    public void CreateRandom(int cloneNumber)
    {
        if (cloneNumber < 3)
        {
            int random_row = Random.Range(0, 3);
            int random_column = Random.Range(0, 5);
            if (!treeGrid[random_row][random_column].gameObject.activeSelf)
            {
                cloneNumber += 1;
                treeGrid[random_row][random_column].gameObject.SetActive(true);
                float pos_y = treeGrid[random_row][random_column].gameObject.transform.position.y;
                spawnPos[1] = pos_y;
                int random_pos_x = Random.Range(-1, 0);
                if (random_pos_x == -1)
                    spawnPos[0] *= random_pos_x;
                Vector3 enemyPos = new Vector3(spawnPos[0], spawnPos[1], -1 * (random_row+1));
//                StartCoroutine(CreateEnemy(enemyPos));
				//InvokeRepeating("CreateEnemy",2f,2f);
            }
            CreateRandom(cloneNumber);
        }
    }

   IEnumerator CreateEnemy(Vector3 enemyPos)
    {
		yield return new WaitForSeconds(2);
        Instantiate(villain, enemyPos, Quaternion.identity);
//        yield return 2f;
    }

    public static void UpdatePolRate(float newPolRate)
    {
        polRate -= newPolRate;
    }
}
