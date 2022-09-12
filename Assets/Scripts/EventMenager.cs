using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventMenager : MonoBehaviour
{
    public static UnityEvent<int> OnMoneyChange = new UnityEvent<int>();
    public static UnityEvent<int> OnLvlChange = new UnityEvent<int>();

    public static void SendMooneyChanged(int money)
    {
        OnMoneyChange.Invoke(money);
    }
    
    public static void SendLvlChanged(int lvl)
    {
        OnLvlChange.Invoke(lvl);
    }
}
