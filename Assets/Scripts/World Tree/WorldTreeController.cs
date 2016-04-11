using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;

public class WorldTreeController : MonoBehaviour {
    public Text progressText;
    public Text goldLeafText;
    public float progress_percentage;
    public ProgressTracker progress;

    public bool infoClicked;
    public GameObject worldTreeBackground;
    public GameObject worldTreeInfo;
    public GameObject worldTreeObj;

    void Start()
    {
        string path = Application.persistentDataPath + "/worldTree";
        string[] data = File.ReadAllLines(path);
        WorldTreeProgress.worldTreeData.goldLeafRecieved = Int32.Parse(data[0]);
        UpdateProgress();
        worldTreeInfo.SetActive(false);
        infoClicked = false;
        worldTreeBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        worldTreeObj.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

    }

    // Update is called once per frame
    void UpdateProgress()
    {
        Debug.Log(WorldTreeProgress.worldTreeData.goldLeafRecieved);
        progress_percentage = (WorldTreeProgress.worldTreeData.goldLeafRecieved / 10000f) * 100;
        progressText.text = "Progress: " + (int) progress_percentage + "% ";
        goldLeafText.text = UserDataInGame.userData.goldLeaf.ToString();
        progress.UpdateProgressMeter();
    }
    
    public void ClickInfo()
    {
        if (!infoClicked)
        {
            worldTreeBackground.GetComponent<Image>().color = new Color32(75, 73, 73, 255);
            worldTreeObj.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 37);
        }
        else
        {
            worldTreeBackground.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            worldTreeObj.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
        }
        worldTreeInfo.SetActive(!worldTreeInfo.activeSelf);
        infoClicked = !infoClicked;
    }

    public void ClickDonate()
    {
        if (UserDataInGame.userData.goldLeaf >= 1)
        {
            WorldTreeProgress.worldTreeData.goldLeafRecieved += 1;
            UserDataInGame.userData.goldLeaf -= 1;
            UpdateProgress();

            string path = Application.persistentDataPath + "/worldTree";
            string[] data = File.ReadAllLines(path);
            int value = Int32.Parse(data[0]);
            value = WorldTreeProgress.worldTreeData.goldLeafRecieved;
            Debug.Log(value);
            File.Create(path).Dispose();
            data[0] = value + "";
            File.WriteAllLines(path, data);

            UpdateUserData(UserDataInGame.userData.username);
        }  
    }

    void UpdateUserData(string user)
    {
        string path = Application.persistentDataPath + "/personal_user";

        // in case user "too" clever and delete the database 
        if (!File.Exists(path))
        {
            Debug.Log("something wrong, call 911");
        }

        string[] THE_DATA = File.ReadAllLines(path);

        // check the data 1 by 1
        for (int i = 0; i < THE_DATA.Length; i++)
        {
            string DATA;

            DATA = THE_DATA[i];
            string[] CURRENT_DATA = DATA.Split(' ');

            if (user == CURRENT_DATA[0])
            {

                CURRENT_DATA[0] = UserDataInGame.userData.username;
                CURRENT_DATA[1] = UserDataInGame.userData.achievement;
                CURRENT_DATA[2] = UserDataInGame.userData.wave + "";
                CURRENT_DATA[3] = UserDataInGame.userData.time + "";
                CURRENT_DATA[4] = UserDataInGame.userData.treePlanted + "";
                CURRENT_DATA[5] = UserDataInGame.userData.enemyKilled + "";
                CURRENT_DATA[6] = UserDataInGame.userData.treeWatered + "";
                CURRENT_DATA[7] = UserDataInGame.userData.treeHealed + "";
                CURRENT_DATA[8] = UserDataInGame.userData.treeSold + "";
                CURRENT_DATA[9] = UserDataInGame.userData.suePaperPurchased + "";
                CURRENT_DATA[10] = UserDataInGame.userData.goldLeaf + "";

                THE_DATA[i] = CURRENT_DATA[0] + " " +
                CURRENT_DATA[1] + " " +
                CURRENT_DATA[2] + " " +
                CURRENT_DATA[3] + " " +
                CURRENT_DATA[4] + " " +
                CURRENT_DATA[5] + " " +
                CURRENT_DATA[6] + " " +
                CURRENT_DATA[7] + " " +
                CURRENT_DATA[8] + " " +
                CURRENT_DATA[9] + " " +
                CURRENT_DATA[10] + " " +
                CURRENT_DATA[11] + " " +
                CURRENT_DATA[12] + " " +
                CURRENT_DATA[13];

                Debug.Log(THE_DATA[i]);
            }
        }

        File.WriteAllLines(path, THE_DATA);
    }
}
