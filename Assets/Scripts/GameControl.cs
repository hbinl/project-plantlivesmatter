using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    public List<List<TreeSci>> treeGrid = new List<List<TreeSci>>();
    public List<TreeSci> row0 = new List<TreeSci>();
    private List<float> spawnPos = new List<float> { 11.0f, 0.0f };

    // private float polRate;
    private int treeNumber;
    public TreeSci tree;
    public GameObject gameOver;
    public static GameObject selectedObject;
    public Enemy villain;
    public bool alive;

    public meterController meterCon;
	public Text coinText;
	public Text suePaperText;
	public Text highscoreText;
    

	public static float Co2Value;
    public static float polRate;
    public static float highScore;
    public static int coinValue;
<<<<<<< HEAD
    public static int waveNumber;
    public static int enemyNumber;
    public Text waveText;
=======
	public static int suePaperValue;
>>>>>>> c9eb3aa86b0c1ffb72114a832762b75b3adb096e

    void Start()
    {
        Co2Value = 0.5f;
        polRate = 50;
        waveNumber = 1;
        treeNumber = 0;
        CreateFullTrees();
        alive = true;
<<<<<<< HEAD
        enemyNumber = 0;
        CreateRandomTree(treeNumber);
=======
        cloneNumber = 0;
        CreateRandom(cloneNumber);

		suePaperValue = 3;
		coinValue = 100;
		highScore = 0f;
>>>>>>> c9eb3aa86b0c1ffb72114a832762b75b3adb096e
        //CreateEnemy();
    }

	// Update is called once per frame
	void Update () {
        meterCon.UpdateMeterPointer(polRate);

		UpdateGameUI();
    }

    IEnumerator GameLoop()
    {
        yield return StartCoroutine(Waves());
        yield return StartCoroutine(WavesActive());
        yield return StartCoroutine(End());
    }

    IEnumerator Waves()
    {
        waveText.text = "Wave " + waveNumber;
        waveNumber += 1;
        yield return new WaitForSeconds(2f);
    }

    IEnumerator WavesActive()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            StartCoroutine(CreateEnemy());
            enemyNumber += 1;
        }
        while (enemyNumber != 0)
        {
            yield return null;
        }
    }

    IEnumerator End()
    {
        gameOver.SetActive(true);
        yield return new WaitForSeconds(2f);
    }

    void CreateTreeList()
    {
        for (int i = 0; i < 3; i++)
        {
            row0.Clear();
            for (int j = 0; j < 5; j++)
            {
                row0.Add(null);
            }
            treeGrid.Add(row0);
        }
    }

    void InsertTreeInList(int row, int column)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i == row && j == column)
                {
                    TreeSci anObj;
                    Vector3 treePos = RandomTreePos(row, column);
                    anObj = Instantiate(tree, treePos, Quaternion.identity) as TreeSci;
                    treeGrid[row][column] = anObj;
                }
            }
        }
    }

    void CreateRandomTree(int number)
    {
        while (number < 5)
        {
            int row = Random.Range(0, 3);
            int column = Random.Range(0, 5);
            Debug.Log("row" + row);
            Debug.Log("column" + column);
            if (treeGrid[row][column] == null)
            {
                number += 1;
                InsertTreeInList(row, column);
                Debug.Log("Created " + number);
                float pos_y = treeGrid[row][column].gameObject.transform.position.y;
                spawnPos[1] = pos_y;
                int random_pos_x = Random.Range(-1, 0);
                if (random_pos_x == -1)
                    spawnPos[0] *= random_pos_x;
                Vector3 enemyPos = new Vector3(spawnPos[0], spawnPos[1], -1 * (row + 1));
                //StartCoroutine(CreateEnemy(enemyPos));
            }
            Debug.Log("repeat");
        }
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

    Vector3 RandomTreePos(int row, int column)
    {
        float x_pos_offset = -3.7f;
        float y_pos_offset = 1.2f;
        float x_gap = 1.8f;
        float x_pos = x_pos_offset - (row * 0.4f); ;
        float y_pos = y_pos_offset;
        x_pos += column * (x_gap + (row * 0.2f));
        y_pos = y_pos_offset - (row * 1.4f);
        float z_pos = row * -1;
        Vector3 treePos = new Vector3(x_pos, y_pos, z_pos);
        return treePos;
    }

    Vector3 RandomEnemyPos()
    {
        float x_pos = 11f;
        int random_flip = Random.Range(0, 2);
        int random_row = Random.Range(0, 3);
        if (random_flip == 0)
        {
            x_pos *= -1;
        }
        float y_pos = 1.2f - (random_row * 1.4f);
        float z_pos = -1 * random_row;
        Vector3 enemyPos = new Vector3(x_pos, y_pos, z_pos);
        return enemyPos;
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

   IEnumerator CreateEnemy()
    {
		yield return new WaitForSeconds(2);
        Vector3 enemyPos = RandomEnemyPos();
        Instantiate(villain, enemyPos, Quaternion.identity);
//        yield return 2f;
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
