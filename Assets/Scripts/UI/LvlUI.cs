using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlUI : MonoBehaviour
{
    [SerializeField] private Text _LevelText;

    private void Start()
    {
        EventMenager.OnLvlChange.AddListener(UpdateUI);
    }

    private void UpdateUI(int lvl)
    {
        _LevelText.text = lvl.ToString();
    }
}
