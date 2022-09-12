using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    //наверное лучше через ивент или delegate
    [SerializeField]
    private Text _moneyText;

    private void Start()
    {
        EventMenager.OnMoneyChange.AddListener(UpdateUI);
    }

    private void UpdateUI(int money)
    {
        _moneyText.text = money.ToString();
    }
}
