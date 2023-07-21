using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : Pickup
{
    public override void PickMeUp()
    {
        Inventory.CurrentCoins++;
        UIManager.UpdateCoins();
        gameObject.SetActive(false);
    }
}
