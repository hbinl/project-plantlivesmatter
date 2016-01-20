using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class SproutGameController : MonoBehaviour
{
    public Camera cam;
    public GameObject sproutGameCon;
    public GameObject tempTestWater;
    public GameObject tempTestSun;
    public GameObject tempTestLove;

    public Plant sprout;
    public Text healthText;
    public Text timerText;
    public Text goldLeafText;
    public Text plantName;
    public Image expProgress;

    private bool playing = false;
    private float time = 1;
    private float progress;
    private float hpDecayRate = -0.15f;

    private Plant saveFile;

    public GameObject sproutUI;
    public SpriteRenderer[] sproutSprites;

    public void fakeRain()
    {

        Instantiate(tempTestWater,
            new Vector3(0,
                        cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0.0f)).y,
                        0.0f),
        Quaternion.identity);
        sprout.addHP(2);
        sprout.addGoldLeaf(-1);
    }
    public void fakeSun()
    {
        Instantiate(tempTestSun, new Vector3(0,
        cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0.0f)).y, 0.0f),
        Quaternion.identity);
    }
    public void fakeLove()
    {
        Instantiate(tempTestLove, new Vector3(0,
        cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0.0f)).y, 0.0f),
        Quaternion.identity);
    }


    // Use this for initialization
    void Start()
    {
        //name = loadSaveData();
        name = "Edward";
        sprout = new Plant(name);
        plantName.text = name;
        expProgress.fillAmount = 0;

        sproutSprites = sproutUI.GetComponentsInChildren<SpriteRenderer>();
        // foreach(SpriteRenderer spr in sproutSprites) {
        //     Debug.Log(spr.gameObject.name);
        // }

        playing = true;


    }


    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            checkHealth();

            goldLeafText.text = sprout.getGoldLeaf() + "/10";

            time += Time.deltaTime;
            timerText.text = "Time: " + Mathf.RoundToInt(time);

            if (Mathf.RoundToInt(time) % 10 == 0) { sprout.addHP(hpDecayRate); }
            if (Mathf.RoundToInt(time) % 30 == 0) { sprout.addGoldLeaf(1); }

            healthText.text = "Health: " + Mathf.RoundToInt(sprout.getHP());

            progress += Time.deltaTime;
            if (progress > 10) progress = 0;
            expProgress.fillAmount = Mathf.Clamp(progress, 0, 10) / 10;

        }

    }

    private void checkHealth()
    {
        float HPCalc = sprout.getHP() / sprout.getMaxHP();
        Color color = new Color(HPCalc * 1.5f, HPCalc, HPCalc, 1);
        foreach (SpriteRenderer spr in sproutSprites)
        {
            spr.color = color;
        }
    }


    private void loadGameData()
    {

    }

    private string loadSaveData()
    {
        string path;


        path = Application.persistentDataPath;

        path = path + "/Save/1.xml";
        var serializer = new XmlSerializer(typeof(Plant));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            saveFile = serializer.Deserialize(stream) as Plant;
        }
        return saveFile.getName();
    }


}
