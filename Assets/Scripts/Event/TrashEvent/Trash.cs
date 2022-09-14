using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [Header("Продолжительность жизни")]
    [SerializeField] private int _hp;
    [SerializeField] private int _damag;
    private EventMenager EventMenager;

    private void Awake()
    {
        EventMenager.OffSpawnVisitoPoint();
    }
    public void OnMouseDown()
    {
        _hp -= _damag;
        if(_hp <= 0)
        {
            Destroy(gameObject);
            EventMenager.OnSpawnVisitoPoint();
        }
    }


}
