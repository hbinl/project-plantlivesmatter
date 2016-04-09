using UnityEngine;
using System.Collections;

public class ButtonInteraction : MonoBehaviour {
    public ItemSlot itemSlot;

	public void ClickStoreItem_1()
    {
        itemSlot.TriggerItem_1();
    }

    public void ClickStoreItem_2()
    {
        itemSlot.TriggerItem_2();
    }

    public void ClickStoreItem_3()
    {
        itemSlot.TriggerItem_3();
    }

    public void ClickBuyGoldLeaf()
    {
        UserDataInGame.userData.goldLeaf += 50;
    }
}
