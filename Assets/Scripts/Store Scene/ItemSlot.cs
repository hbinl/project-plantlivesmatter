using UnityEngine;
using System.Collections;

public class ItemSlot : MonoBehaviour {
    public int costItem_1;
    public int costItem_2;
    public int costItem_3;
    public static bool chirstmasPack;
    public static bool boostSuePaper;
    public static bool boostCoin;
  
    void Start()
    {
        costItem_1 = 30;
        costItem_2 = 10;
        costItem_3 = 10;
        if (UserDataInGame.userData.boughtItem_1 == 0)
        {
            chirstmasPack = true;
        }
        else
        {
            chirstmasPack = false;
        }
    }

    public void TriggerItem_1()
    {
        if (UserDataInGame.userData.goldLeaf >= costItem_1 && UserDataInGame.userData.boughtItem_1 == 0)
        {
            chirstmasPack = true;
            UserDataInGame.userData.goldLeaf -= costItem_1;
        }
        else
        {
            chirstmasPack = false;
        }
    }

    public void TriggerItem_2()
    {
        if (UserDataInGame.userData.goldLeaf >= costItem_2 && UserDataInGame.userData.boughtItem_2 == 0)
        {
            boostSuePaper = true;
            UserDataInGame.userData.goldLeaf -= costItem_2;
        }
        else
        {
            boostSuePaper = false;
        }
    }

    public void TriggerItem_3()
    {
        if (UserDataInGame.userData.goldLeaf >= costItem_3 && UserDataInGame.userData.boughtItem_3 == 0)
        {
            boostCoin = true;
            UserDataInGame.userData.goldLeaf -= costItem_3;
        }
        else
        {
            boostCoin = false;
        }
    }
}
