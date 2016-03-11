using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {
    public List<List<TreeSci>> treeGrid = new List<List<TreeSci>>();
    public List<TreeSci> row0 = new List<TreeSci>();
    private List<float> spawnPos = new List<float> { 11.0f, 0.0f };

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
    public static bool timerActive;
    public static float timer;
    public static int suePapers;
    public static int waveNumber;
    public Text timerText;
    public Text highScoreText;
    public Text suePapersText;
    public Text coinText;
    public Text waveText;

    void Start()
    {
           
        Co2Value = 0.5f;
        polRate = 50;
        coinValue = 10;
        CreateFullTrees();
        alive = true;
        cloneNumber = 0;
        highScore = 0;
        suePapers = 1;
        timerActive = true;
        waveNumber = 1;
        //CreateTreeList();
        //CreateEnemy();
        //CreateRandomTree(cloneNumber);
    }

    // Update is called once per frame
    void Update() {
        meterCon.UpdateMeterPointer(polRate);
        coinText.text = coinValue.ToString();
        highScoreText.text = highScore.ToString();
        suePapersText.text = suePapers.ToString();
        if (timerActive)
        {
            timer += Time.deltaTime;
            highScore += 1.0f;
        }
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(Waves());
    }

    IEnumerator Waves()
    {

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
                anObj.gameObject.SetActive(true);
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
            int random_row = Random.Range(0, 2);
            int random_column = Random.Range(0, 4);
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
                //StartCoroutine(CreateEnemy(enemyPos));
            }
            CreateRandom(cloneNumber);
        }
    }

   IEnumerator CreateEnemy(Vector3 enemyPos)
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 6.0f));
        Instantiate(villain, enemyPos, Quaternion.identity);
    }

    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer-minutes / 60);
        timerText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }
}
