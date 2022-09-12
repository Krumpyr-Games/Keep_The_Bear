using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public ItemObject[] items;
    public void BuyItem(ItemObject target) // Покупаем Предмет;
    {
        if(target.Cost > PlayerStats.Instance.Money) { return; }

        if (target.isBuyed == 0)
        {
            PlayerStats.Instance.RemoveMoney(target.Cost);

            target.Buy();
        }       
    }
}
