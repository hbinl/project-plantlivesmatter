using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {

    // for button toolbar
	public static bool treeButtonUI;
	public static bool waterButtonUI;
	public static bool medicineButtonUI;
	public static bool sellButtonUI;

    public List<TreeSci> treeGrid = new List<TreeSci>();
    public List<Enemy> enemyList = new List<Enemy>();
    public List<Enemy> enemyTypes = new List<Enemy>();
    public List<TileScript> tileScriptObject;
    public List<GameObject> enemyWaypoints;
    public List<GameObject> spawnPoints = new List<GameObject>();

    private int cloneNumber;
    public TreeSci tree;
    public GameObject gameOverBoard;
    
    public bool alive;
    public int multipleEnemySpawnNumber;
    public float prob_MultiSpawn;
    public float aSecond;
    public float pointsTimer;
    public meterController meterCon;

	public Text coinText;
	public Text suePaperText;
	public Text highscoreText;
    public Text timerText;
    public Text waveText;

	public static GameObject selectedObject;
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

    // public static bool canSpawnTree;    	

    float min_spawnTime = 4f;
    float max_spawnTime = 5f;
    void Awake()
    {
		// set it to false
		treeButtonUI = false;
		waterButtonUI = false;
		medicineButtonUI = false;
		sellButtonUI = false;

	//	canSpawnTree = false;
        wavesStarted = false;
        wavesEnded = false;

        aSecond = 1.0f;
        timer = 0f;
        pointsTimer = 60f;

        Co2Value = 0.5f;
        polRate = 97;
        meterCon.UpdateMeterPointer(polRate);

        waveNumber = 1;
        alive = true;
        cloneNumber = 6;
        CreateRandomTree(cloneNumber);

		suePaperValue = 3;
		coinValue = 100;
		highScore = 0f;
        StartCoroutine(GameLoop());

        multipleEnemySpawnNumber = 2;
        prob_MultiSpawn = 0.8f;
    }

	void Update () {
		// will run after the first wave is called 
		// so that the timer will not start before the first wave
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

		// clear the list
        enemyList.RemoveAll((o) => o == null);
        treeGrid.RemoveAll((o) => o == null);
    }

    IEnumerator GameLoop()
    {
		// endless game loop
        while(true)
        {
			// if the waves is ended, then break the loop
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
		// show the wave text for 5 seconds
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
        // making the game harder 10mins (every 3 waves till 15: min_spawn -=0.5, prob -= 0.15 till wave 12, numberOfSpawn += 1 from 6 till 6 waves)
        if (waveNumber % 2 == 0 && waveNumber != 0 && waveNumber < 11)
        {
            min_spawnTime -= 0.5f;
            max_spawnTime -= 0.5f;
            if (waveNumber < 12)
                prob_MultiSpawn -= 0.15f;
            if (waveNumber >= 4 && waveNumber <= 8)
                multipleEnemySpawnNumber += 1;
        }
            
        while (i<waveNumber+2 && polRate <= 99f)
        {
            float rand = Random.value;
            yield return new WaitForSeconds(Random.Range(min_spawnTime, max_spawnTime));
            if (rand >= 0 && rand < 0.8 || waveNumber < 3)
            {
                Debug.Log("Spawn One");
                CreateEnemy();
                i++;
            }
            else
            {
                Debug.Log("Spawn Multiple");
                CreateEnemies(multipleEnemySpawnNumber);
                i = i + multipleEnemySpawnNumber;
            }
            
        }
        while (enemyList.Count > 0 && polRate <= 99f)
        {
            yield return null;
        }
    }

    IEnumerator GameOver()
    {
		// check if the the game ends
        if (polRate >= 99f)
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
		// spawn a random tree for the first time when the game is run
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
		// spawn the enemy depends on the enemy start waypoints position
		float posX, posY, posZ;
		int randomPos = Random.Range(0,6);
        
		posX = enemyWaypoints[randomPos].transform.position.x;
		posY = enemyWaypoints[randomPos].transform.position.y;
		posZ = enemyWaypoints[randomPos].transform.position.z;

		return new Vector3(posX,posY,posZ);
    }

    GameObject RandomSpawn()
    {
        int randomPos = Random.Range(0, 6);
        return enemyWaypoints[randomPos];
    }

    bool SearchList(GameObject target)
    {

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (spawnPoints[i].transform.gameObject == target.transform.gameObject)
                return true;
        }
        return false;
    }

    void CreateEnemies(int enemyNum)
    {        
        spawnPoints.Clear();
        int n = 0;
        while (n < enemyNum)
        {
            float prob_value = Random.value;
            int randomInt = 0;
            if (prob_value >= .50)
            {
                randomInt = 0;
            }
            else if (prob_value <= .30 && prob_value >= .20)
            {
                randomInt = 1;
            }
            else if (prob_value <= .20)
            {
                randomInt = 2;
            }
            Enemy randomType = enemyTypes[randomInt];
            GameObject enemySpawn = RandomSpawn();
            Vector3 enemyPos = new Vector3(enemySpawn.transform.position.x, enemySpawn.transform.position.y, enemySpawn.transform.position.z);
            if (!SearchList(enemySpawn))
            {
                spawnPoints.Add(enemySpawn);
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
                n += 1;
            }
        }
    }

  	void CreateEnemy()
    {
        // create enemy function to instantiate enemy and set the face direction
        //int randomInt = Random.Range(0, enemyTypes.Count);
        float prob_value = Random.value;
        int randomInt = 0;
        if (prob_value >= .50)
        {
            randomInt = 0;
        }
        else if (prob_value <= .30 && prob_value >= .20)
        {
            randomInt = 1;
        }
        else if (prob_value <= .20)
        {
            randomInt = 2;
        }
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
		// convert 25 coins to 1 sue paper
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
		// every function calls will consume 1 sue paper
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
		// keep update the highscore for every minute
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
		// update the UI
		coinText.text = coinValue.ToString();
		suePaperText.text = suePaperValue.ToString();
		highscoreText.text = highScore.ToString();
	}

    void OnGUI()
    {
		// to format the time of the Time
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

	// Toolbar boolean interaction
	public static void OnTreeButtonClick()
	{
        OnButtonClearClick();
		treeButtonUI = true;
	}

	public static void OnWaterButtonClick()
	{
		OnButtonClearClick();
		waterButtonUI = true;
	}

	public static void OnMedicineButtonClick()
	{
		OnButtonClearClick();
		medicineButtonUI = true;
	}

	public static void OnSellButtonClick()
	{
		OnButtonClearClick();
		sellButtonUI = true;
	}

	public static void OnButtonClearClick()
	{
		treeButtonUI = false;
		waterButtonUI = false;
		medicineButtonUI = false;
		sellButtonUI = false;
	}
	// END toolbar boolean interaction
}