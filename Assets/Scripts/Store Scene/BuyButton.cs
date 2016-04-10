using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public class BuyButton : MonoBehaviour
{

    // Update is called once per frame
    public void ClickBuy()
    {
        UserDataInGame.userData.goldLeaf += 50;
        UpdateUserData(UserDataInGame.userData.username);
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
            }
        }
        File.WriteAllLines(path, THE_DATA);
    }
}
