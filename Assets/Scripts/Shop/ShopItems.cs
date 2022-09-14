using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItems : IShopItem
{
    #region Values
    [Header("Item Info")]
    [SerializeField]
    private string _name;

    [SerializeField]
    private int _cost;

    [SerializeField]
    private int _lvlRequired;

    [SerializeField]
    private GameObject[] _targetObjects;

    [SerializeField]
    private Sprite _itemSprite;

    [Header("UI Info")]
    [SerializeField]
    private Image _image;

    [SerializeField]
    private TextMeshProUGUI _text;

    #endregion

    #region Logic
    private void Start()
    {
        Render();
        _image.sprite = _itemSprite;
        _text.text = _cost.ToString();
    }

    public override void Buy()
    {
        Debug.Log("TRY BUY");
        if (PlayerStats.Instance.Money >= _cost && CheckBuy() == 0)
        {
            PlayerStats.Instance.RemoveMoney(_cost);

            PlayerPrefs.SetInt(_name, 1);

            Debug.Log("BUYED");

            foreach (var item in _targetObjects)
            {
                item.SetActive(true);
            }
        }
    }

    public override void Render()
    {
        if (PlayerStats.Instance.Level >= _lvlRequired)
        {
            if (CheckBuy() == 1)
            {
                foreach (var item in _targetObjects)
                {
                    item.SetActive(true);
                }
            }
            else
            {
                foreach (var item in _targetObjects)
                {
                    item.SetActive(false);
                }
            }

        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    private int CheckBuy()
    {
        return PlayerPrefs.GetInt(_name);
    }
    #endregion
}
