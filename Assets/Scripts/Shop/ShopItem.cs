using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ShopItem : IShopItem
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
    private GameObject _targetObject;

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

            Render();
        }
    }

    public override void Render()
    {
        if (PlayerStats.Instance.Level >= _lvlRequired)
        {
            if (CheckBuy() == 1)
            {
                _targetObject.SetActive(true);
            }
            else
            {
                _targetObject.SetActive(false);
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
