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

    // Update is called once per frame
    void Update()
    {
        progress_percentage = (WorldTreeProgress.worldTreeData.goldLeafRecieved / 10000) * 100;
        progressText.text = "Progress: " + (int)progress_percentage + "% ";
        goldLeafText.text = UserDataInGame.userData.goldLeaf.ToString();
    }

    public void ClickDonate()
    {
        WorldTreeProgress.worldTreeData.goldLeafRecieved += 1;
        UserDataInGame.userData.goldLeaf -= 1;
        progress.UpdateProgressMeter();

        string path = Application.persistentDataPath + "/worldTree";
        string[] data = File.ReadAllLines(path);
        string[] value = data[0].Split(' ');
        value[0] = Int32.Parse(value[0]) + WorldTreeProgress.worldTreeData.goldLeafRecieved + "";
        Debug.Log(value[0]);
        File.WriteAllLines(path,data);    
    }
}
