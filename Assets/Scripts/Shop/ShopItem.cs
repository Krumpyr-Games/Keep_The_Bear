using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ShopItem
{
    [Header("Canvas")]
    public Transform Content;
    public GameObject ButtonPrefab;
    public Sprite ShopSprite;

    [Header("General Settings")]
    public int Cost;
    public int LvlToUnlock;

    [Header("Type of activation on scene")]
    public InitiateType type = InitiateType.activate;

    [Header("For activation type")]
    public GameObject ActivateGameObject;

    [Header("For initiation type")]
    public GameObject InitiatePrefab;
    public Transform InitiatePlace;


}

public enum InitiateType
{
    activate,
    initiate
}
