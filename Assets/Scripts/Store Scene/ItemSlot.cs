using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;

public class ItemSlot : MonoBehaviour {
    public int costItem_1;
    public int costItem_2;
    public int costItem_3;
    public static bool christmasPack;
    public static bool boostSuePaper;
    public static bool boostCoin;
  
    void Start()
    {
        costItem_1 = 30;
        costItem_2 = 10;
        costItem_3 = 10;
        if (UserDataInGame.userData.boughtItem_1 == 0)
        {
            christmasPack = true;
        }
        else
        {
            christmasPack = false;
        }
    }

    public void TriggerItem_1()
    {
        if (UserDataInGame.userData.goldLeaf >= costItem_1 && UserDataInGame.userData.boughtItem_1 == 0)
        {
            christmasPack = true;
            UserDataInGame.userData.goldLeaf -= costItem_1;
            UserDataInGame.userData.boughtItem_1 = 1;
            UpdateUserData(UserDataInGame.userData.username);
        }
    }

    public void TriggerItem_2()
    {
        if (UserDataInGame.userData.goldLeaf >= costItem_2 && UserDataInGame.userData.boughtItem_2 == 0)
        {
            boostCoin = true;
            UserDataInGame.userData.goldLeaf -= costItem_2;
            UserDataInGame.userData.boughtItem_2 = 1;
            UpdateUserData(UserDataInGame.userData.username);
        }
    }

    public void TriggerItem_3()
    {
        if (UserDataInGame.userData.goldLeaf >= costItem_3 && UserDataInGame.userData.boughtItem_3 == 0)
        {
            boostSuePaper = true;
            UserDataInGame.userData.goldLeaf -= costItem_3;
            UserDataInGame.userData.boughtItem_3 = 1;
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
                CURRENT_DATA[11] = UserDataInGame.userData.boughtItem_1 + "";
                CURRENT_DATA[12] = UserDataInGame.userData.boughtItem_2 + "";
                CURRENT_DATA[13] = UserDataInGame.userData.boughtItem_3 + "";

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
