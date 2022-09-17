using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopItem : IItem
{
    [Header("ITEM SETTINGS")]
    [SerializeField]
    private GameObject _itemObject;

    [SerializeField]
    private string _name;

    [SerializeField]
    private int _cost;

    [SerializeField]
    private Sprite _itemSprite;

    [Header("UI")]
    [SerializeField]
    private Image _itemImage;

    [SerializeField]
    private TextMeshProUGUI _itemText;

    public override int isBuyed => PlayerPrefs.GetInt(_name);

    private void Start()
    {
        _itemImage.sprite = _itemSprite;
        _itemText.text = _cost.ToString();
    }

    public override void Buy()
    {
        if(PlayerStats.Instance.Money >= _cost && isBuyed == 0)
        {
            PlayerStats.Instance.RemoveMoney(_cost);
            PlayerPrefs.SetInt(_name, 1);
            Debug.Log($"BUYED : {name} / MONEY : {PlayerStats.Instance.Money}");
            Render();
        }
        
    }

    public override void Render()
    {
        _itemObject.SetActive(true);
    }
}
