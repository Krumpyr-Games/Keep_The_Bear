using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField]
    private string m_UniqueName;

    public int Cost;
    public int isBuyed { get; private set; }

    private void Awake()
    {
        isBuyed = PlayerPrefs.GetInt(m_UniqueName);
        Debug.Log("Check");
        if(isBuyed == 1)
        {
            Debug.Log("True");
            RenderObject();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void Buy()
    {
        isBuyed = 1;
        PlayerPrefs.SetInt(m_UniqueName, isBuyed);
        RenderObject();

    }
    public void RenderObject()
    {
        gameObject.SetActive(true);
    }
}
