using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    GameObject[] VolumePanel = new GameObject[3];

    public void StartMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        for (int i = 0; i < VolumePanel.Length; i++)
        {
            VolumePanel[i].SetActive(true);
        }
    }

    public void SettingsMenuExit()
    {
        for (int i = 0; i < VolumePanel.Length; i++)
        {
            VolumePanel[i].SetActive(false);
        }
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
    }
}

