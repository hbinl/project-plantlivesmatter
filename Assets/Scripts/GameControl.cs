using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {
    public List<TreeSci> treeGrid = new List<TreeSci>();
    public List<Enemy> enemyList = new List<Enemy>();
    public List<Enemy> enemyTypes = new List<Enemy>();
    public List<TileScript> tileScriptObject;
    public List<GameObject> enemyWaypoints;

    private int cloneNumber;
    public TreeSci tree;
    public GameObject gameOverBoard;
    public static GameObject selectedObject;
    public bool alive;
    public float aSecond;
    public float pointsTimer;
    public meterController meterCon;
	public Text coinText;
	public Text suePaperText;
	public Text highscoreText;
    public Text timerText;
    public Text waveText;
    public static int enemyKilled;
	public static float Co2Value;
    public static float polRate;
    public static float highScore;
    public static float timer;
    public static int coinValue;
    public static int waveNumber;
    public static int enemyNumber;
    public static int suePaperValue;
    public static bool wavesStarted;
    public static bool wavesEnded;
    public static bool canSpawnTree;    	

    void Start()
    {
		canSpawnTree = false;
        wavesStarted = false;
        aSecond = 1.0f;
        timer = 0f;
        pointsTimer = 60f;
        Co2Value = 0.5f;
        polRate = 50;
        waveNumber = 1;
        alive = true;
        cloneNumber = 6;
        CreateRandomTree(cloneNumber);
		suePaperValue = 3;
		coinValue = 100;
		highScore = 0f;
        StartCoroutine(GameLoop());
    }

	// Update is called once per frame
	void Update () {
        if (wavesStarted)
        {
            timer += Time.deltaTime;
            UpdateHighScore();
            if (aSecond <= 0)
            {
                GameControl.polRate += 0.375f;
                aSecond = 1.0f;
            }
            else
            {
                aSecond -= Time.deltaTime;
            }
            meterCon.UpdateMeterPointer(polRate);
            UpdateGameUI();
        }
        enemyList.RemoveAll((o) => o == null);
        treeGrid.RemoveAll((o) => o == null);
    }

    IEnumerator GameLoop()
    {
        while(true)
        {
            if (!wavesEnded)
            {
                yield return StartCoroutine(Waves());
                yield return StartCoroutine(WavesActive());
                yield return StartCoroutine(GameOver());
            }
            else
            {
                break;
            }
            
        }
    }

    IEnumerator Waves()
    {
        waveText.gameObject.SetActive(true);
        waveText.text = "Wave " + waveNumber;
        waveNumber += 1;
        yield return new WaitForSeconds(5f);
        waveText.text = "";
        waveText.gameObject.SetActive(false);
    }

    IEnumerator WavesActive()
    {
        // only need for the first wave, so that there is a delay before the enemy spawn
        wavesStarted = true;
        int i = 0;
        while (i<waveNumber+2 && polRate <= 100f)
        {
            yield return new WaitForSeconds(Random.Range(4f, 8f));
            CreateEnemy();
            i++;
        }
        while (enemyList.Count > 0 && polRate <= 100f)
        {
            yield return null;
        }
    }

    IEnumerator GameOver()
    {
        if (polRate >= 100f)
        {
            gameOverBoard.SetActive(true);
            wavesEnded = true;
            wavesStarted = false;
            for (int i = 0;i<enemyList.Count; i++)
            {
                enemyList[i].gameObject.SetActive(false);
            }
            for (int i=0;i<treeGrid.Count; i++)
            {
                treeGrid[i].gameObject.SetActive(false);
            }
            
        }
        yield return null;
    }

    public void CreateRandomTree(int cloneNumber)
    {
        int numberSpawn = 0;
        while (numberSpawn < cloneNumber)
        {
            int random_pos = Random.Range(0, 15);

            if (!tileScriptObject[random_pos].occupied)
            {
                // add Tree to tile grid
                TreeSci aTree;
                float tilePosX, tilePosY, tilePosZ;
                tilePosX = tileScriptObject[random_pos].transform.position.x;
                tilePosY = tileScriptObject[random_pos].transform.position.y + 1f;
                tilePosZ = tileScriptObject[random_pos].transform.position.z - 3;
                aTree = Instantiate(tree, new Vector3(tilePosX, tilePosY, tilePosZ), Quaternion.identity) as TreeSci;
                treeGrid.Add(aTree);

                // add tree object and occupy to the grid
                tileScriptObject[random_pos].occupied = true;
                tileScriptObject[random_pos].treeObject = aTree;

                numberSpawn++;

            }
        }
    }
			
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
    }


  	void CreateEnemy()
    {      
        int randomInt = Random.Range(0, enemyTypes.Count);
        Enemy randomType = enemyTypes[randomInt];
        Vector3 enemyPos = RandomEnemyPos();
        if (randomInt == 2)
            if (enemyPos.x < 0)
            {
                enemyPos.x += 2f;
            }
            else
            {
                enemyPos.x -= 2f;
            }
        Enemy villain;
        villain = Instantiate(randomType, enemyPos, Quaternion.identity) as Enemy;
        enemyList.Add(villain);
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

    public void UpdateHighScore()
    {
        if (pointsTimer <= 0)
        {
            highScore += 100f;
            pointsTimer = 60f;
        }
        else
        {
            pointsTimer -= Time.deltaTime;
        }
    }

	public void UpdateGameUI()
	{
		coinText.text = coinValue.ToString();
		suePaperText.text = suePaperValue.ToString();
		highscoreText.text = highScore.ToString();
	}

    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}