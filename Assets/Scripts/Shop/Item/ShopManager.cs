using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private IItem[] _items;

    private void Start()
    {
        foreach (var item in _items)
        {
            if(item.isBuyed == 1)
            {
                item.Render();
            }
        }
    }
}