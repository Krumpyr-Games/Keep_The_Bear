using UnityEngine;
using UnityEngine.UI;


public class InstantiateButtonsIntoShop : MonoBehaviour
{

    public ShopItem[] shopItems;

    private void Start()
    {
        foreach(ShopItem item in shopItems)
        {
            Button button = InstantiateButton(item);

            switch (item.type)
            {
                case InitiateType.initiate:


                    button.onClick.AddListener(() => {

                        if (PlayerStats.Instance.Money >= item.Cost && PlayerStats.Instance.Level >= item.LvlToUnlock)
                        {

                            PlayerStats.Instance.RemoveMoney(item.Cost);
                            Instantiate(item.InitiatePrefab, item.InitiatePlace.position, Quaternion.identity);
                            button.interactable = false;


                        }

                    });

                    break;

                case InitiateType.activate:


                    button.onClick.AddListener(() => {



                        if (PlayerStats.Instance.Money >= item.Cost && PlayerStats.Instance.Level >= item.LvlToUnlock)
                        {

                            PlayerStats.Instance.RemoveMoney(item.Cost);
                            item.ActivateGameObject.SetActive(true);
                            button.interactable = false;

                        }

                    });

                    break;


                default:
                    break;
            }
        }
    }




    public Button InstantiateButton(ShopItem item)
    {
        GameObject go = Instantiate(item.ButtonPrefab);

        go.transform.SetParent(item.Content, false);
        go.GetComponentInChildren<Text>().text = item.Cost.ToString();
        Image[] images = go.GetComponentsInChildren<Image>();

        images[1].sprite = item.ShopSprite;


        go.GetComponent<Button>();

        return go.GetComponentInChildren<Button>();
    } 


}

