using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private IShopItem[] Items;

    private void Start()
    {
        foreach (var item in Items)
        {
            item.Render();
        }  
    }
}
