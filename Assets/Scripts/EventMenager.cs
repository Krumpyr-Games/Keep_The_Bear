using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventMenager : MonoBehaviour
{
    #region Mony-Level
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
    #endregion

    #region Events

    #region TrashEvent

    #region StartEvent
    //it is for start trash event
    
    //for open spwan poin
    public static Action OffSpawnVisitoPoint;

    //there are for down and up exp
    //public static Action OnDownExp;
    //public static Action UpDownExp;

    #endregion

    #region EndEvent
    //for close spawn point 
    public static Action OnSpawnVisitoPoint;
    #endregion

    #endregion



    #endregion


}
