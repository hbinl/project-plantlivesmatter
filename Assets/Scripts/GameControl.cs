using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {
    public static List<TreeSci> treeGrid = new List<TreeSci>();
    public List<Enemy> enemyList = new List<Enemy>();
    public List<Enemy> enemyTypes = new List<Enemy>();

    // private float polRate;
    private int cloneNumber;
    public TreeSci tree;
    public GameObject gameOver;
    public static GameObject selectedObject;
    public bool alive;

    public meterController meterCon;
	public Text coinText;
	public Text suePaperText;
	public Text highscoreText;
    public static int enemyKilled;
	public static float Co2Value;
    public static float polRate;
    public static float highScore;
    public static int coinValue;
    public static int waveNumber;
    public static int enemyNumber;
    public Text waveText;
	public static int suePaperValue;

	public List<TileScript> tileScriptObject;
	public List<GameObject> enemyWaypoints;

	public static bool canSpawnTree;


    void Start()
    {
		canSpawnTree = false;

        Co2Value = 0.5f;
        polRate = 50;
        waveNumber = 1;
        cloneNumber = 0;
        enemyKilled = 0;
//        CreateFullTrees();
        alive = true;
        cloneNumber = 6;
        CreateRandomTree(cloneNumber);
		suePaperValue = 3;
		coinValue = 100000;
		highScore = 0f;
        StartCoroutine(GameLoop());
    }

	// Update is called once per frame
	void Update () {
        meterCon.UpdateMeterPointer(polRate);

		UpdateGameUI();
    }

    IEnumerator GameLoop()
    {
        for (int i = 0; i < Mathf.Infinity; i++)
        {
            yield return StartCoroutine(Waves());
            yield return StartCoroutine(WavesActive());
        }
    }

    IEnumerator Waves()
    {
        waveText.text = "Wave " + waveNumber;
        waveNumber += 1;
        yield return new WaitForSeconds(2f);
    }

    IEnumerator WavesActive()
    {
        waveText.text = string.Empty;
        for (int i = 0; i < waveNumber + 2; i++)
        {
            yield return new WaitForSeconds(Random.Range(4f, 8f));
            StartCoroutine(CreateEnemy());
            enemyNumber += 1;
        }
        while (enemyNumber != enemyKilled)
        {
            Debug.Log(enemyKilled);
            yield return new WaitForSeconds(Random.Range(4f, 8f));
            StartCoroutine(CreateEnemy());
        }
    }

//    void CreateTreeList()
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            row0.Clear();
//            for (int j = 0; j < 5; j++)
//            {
//                row0.Add(null);
//            }
//            treeGrid.Add(row0);
//        }
//    }

//    void InsertTreeInList(int row, int column)
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            for (int j = 0; j < 5; j++)
//            {
//                if (i == row && j == column)
//                {
//                    TreeSci anObj;
//                    Vector3 treePos = RandomTreePos(row, column);
//                    anObj = Instantiate(tree, treePos, Quaternion.identity) as TreeSci;
//                    treeGrid[row][column] = anObj;
//                }
//            }
//        }
//    }

    public void CreateRandomTree(int cloneNumber)
    {
		int numberSpawn = 0;
		while( numberSpawn < cloneNumber)
		{
			int random_pos = Random.Range(0,15);

			if (!tileScriptObject[random_pos].occupied)
			{
				// add Tree to tile grid
				TreeSci aTree;
				float tilePosX, tilePosY, tilePosZ;
				tilePosX = tileScriptObject[random_pos].transform.position.x;
				tilePosY = tileScriptObject[random_pos].transform.position.y + 1f;
				tilePosZ = tileScriptObject[random_pos].transform.position.z - 3;
				aTree = Instantiate(tree, new Vector3(tilePosX,tilePosY,tilePosZ), Quaternion.identity) as TreeSci;
				treeGrid.Add(aTree);

				// add tree object and occupy to the grid
				tileScriptObject[random_pos].occupied = true;
				tileScriptObject[random_pos].treeObject = aTree;

				numberSpawn++;

			}
		}
			
//        if (cloneNumber < 7)
//        {
//            int random_row = Random.Range(0, 3);
//            int random_column = Random.Range(0, 5);
//            if (!treeGrid[random_row][random_column].gameObject.activeSelf)
//            {
//                cloneNumber += 1;
//                InsertTreeInList(random_row, random_column);
//            }
//            CreateRandom(cloneNumber);
//        }
    }

//    void CreateFullTrees()
//    {
//        float x_pos_offset = -3.7f;
//        float y_pos_offset = 1.2f;
//        float x_gap = 1.8f;
//        float x_pos = x_pos_offset;
//        float y_pos = y_pos_offset;
//        for (int i = 0; i < 3; i++)
//        {
//            row0.Clear();
//            for (int j = 0; j < 5; j++)
//            {
//                TreeSci anObj;
//                anObj = Instantiate(tree, new Vector3(x_pos, y_pos, (i * -1)), Quaternion.identity) as TreeSci;
//                anObj.gameObject.SetActive(false);
//                row0.Add(anObj);
//                x_pos += x_gap;
//            }
//            List<TreeSci> row = new List<TreeSci>(row0);
//            treeGrid.Add(row);
//            x_pos = x_pos_offset - ((i+1) * 0.4f);
//            x_gap += 0.2f;
//            y_pos = y_pos_offset - ((i+1) * 1.4f);
//        }
//    }

//    Vector3 RandomTreePos(int row, int column)
//    {
//        float x_pos_offset = -3.7f;
//        float y_pos_offset = 1.2f;
//        float x_gap = 1.8f;
//        float x_pos = x_pos_offset - (row * 0.4f); ;
//        float y_pos = y_pos_offset;
//        x_pos += column * (x_gap + (row * 0.2f));
//        y_pos = y_pos_offset - (row * 1.4f);
//        float z_pos = row * -1;
//        Vector3 treePos = new Vector3(x_pos, y_pos, z_pos);
//        return treePos;
//    }
//
	public TreeSci SpawnTree(Vector3 pos)
	{
		// add Tree to tile grid
		TreeSci aTree;
		float tilePosX, tilePosY, tilePosZ;
		tilePosX = pos.x;
		tilePosY = pos.y + 1f;
		tilePosZ = pos.z - 3;
		aTree = Instantiate(tree, new Vector3(tilePosX,tilePosY,tilePosZ), Quaternion.identity) as TreeSci;
		treeGrid.Add(aTree);

		return aTree;
	}

	Vector3 RandomEnemyPos()
    {
		float posX, posY, posZ;
		int randomPos = Random.Range(0,6);
        
		posX = enemyWaypoints[randomPos].transform.position.x;
		posY = enemyWaypoints[randomPos].transform.position.y;
		posZ = enemyWaypoints[randomPos].transform.position.z;

		return new Vector3(posX,posY,posZ);

//        float x_pos = 11f;
//        int random_flip = Random.Range(0, 2);
//        int random_row = Random.Range(0, 3);
//        if (random_flip == 0)
//        {
//            x_pos *= -1;
//        }
//        float y_pos = 1.2f - (random_row * 1.4f);
//        float z_pos = -1 * random_row;
//        Vector3 enemyPos = new Vector3(x_pos, y_pos, z_pos);
//        return enemyPos;
    }


  	IEnumerator CreateEnemy()
    {
		yield return new WaitForSeconds(2);        
        int randomInt = Random.Range(0, enemyTypes.Count);
        Enemy randomType = enemyTypes[randomInt];
        Vector3 enemyPos = RandomEnemyPos();
        Instantiate(randomType, enemyPos, Quaternion.identity);
    }

    public static void UpdatePolRate(float newPolRate)
    {
        polRate -= newPolRate;
    }

	public static bool PurchaseSuePaper()
	{
		if (coinValue >= 25)
		{
			coinValue -= 25;
			suePaperValue += 1;

			return true;
		}
		else
		{
			// should return sth to indicate not enough coin to purchase

			return false;
		}
	}

	public static bool useSuePaper()
	{
		if (suePaperValue > 0)
		{
			suePaperValue -= 1;
			return true;
		}
		else
		{
			return false;
		}
	}

	public void UpdateGameUI()
	{
		coinText.text = coinValue.ToString();
		suePaperText.text = suePaperValue.ToString();
		highscoreText.text = highScore.ToString();
	}
}
