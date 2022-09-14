using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Visitor;


public class TrashEvent : MonoBehaviour
{

    [SerializeField] private Trash Trash;

    [Header("Настройка частоты ивента")]   
    [SerializeField] private int _minRange;
    [SerializeField] private int _maxRange;

    [Header("Spawn reat")]
    [SerializeField] private int _spawnReat;

    private void Awake()
    {
        AfterDea += StartEvent;
    }
    public void StartEvent(Transform transform)
    {
        int RandomNumber = Random.Range(_minRange , _maxRange);
        if (RandomNumber < _spawnReat) { return; }
       
        Instantiate(Trash, transform.position, Quaternion.identity);
       
    }
}
