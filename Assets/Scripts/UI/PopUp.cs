using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [SerializeField]
    private GameObject lvlPopUp;
     
    private void Start()
    {
        EventMenager.OnLvlChange.AddListener(ShowPopUp);
    }

    private void ShowPopUp(int value)
    {
        lvlPopUp.SetActive(true);
        lvlPopUp.GetComponentInChildren<Text>().text = value.ToString();
    }
}
