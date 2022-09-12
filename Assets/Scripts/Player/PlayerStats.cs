using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{  
    public int Money { get;private set; }

     
    public static PlayerStats Instance;

    public int Level { get; private set; }

    private int _Exp;
    private int _maxExp;

    [SerializeField]
    private float nextLvlExpCoefficient;



    private void Start()
    {
        Money = PlayerPrefs.GetInt("Money");
        if (Instance != null) { Debug.LogError("One BuildManager at the same time"); return; }
        Instance = this;
        
    }
    public void RemoveMoney(int value)
    {
        if (!(Money >= value))
        {
            Debug.Log("недостаточно денег");
            return;
        }
        Money -= value;

        EventMenager.SendMooneyChanged(Money);
    }

    public void AddMoney(int value)
    {
        if (value <= 0)
        {
            Debug.Log("отрицательное значение");
            return;
        }

        Money += value;

        EventMenager.SendMooneyChanged(Money);
    }


    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Money", Money);
        PlayerPrefs.SetInt("Level", Level);
        PlayerPrefs.SetInt("Exp", _Exp);
        PlayerPrefs.SetInt("MaxExp", _maxExp);
    }

    public void AddExp(int exp)
    {
        if (exp > 0)
        {
            _Exp += exp;

            if(_Exp >= _maxExp)
            {
                Level += 1;

                _Exp = 0;

                _maxExp = (int)(_maxExp * nextLvlExpCoefficient);

                EventMenager.SendLvlChanged(Level);
            }
        }
    }


}
