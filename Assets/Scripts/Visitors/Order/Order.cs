using UnityEngine;

public class Order : MonoBehaviour
{

    [SerializeField]
    private GameObject _orderIcon;
    [SerializeField]
    private int _maxMoneyReward;
    [SerializeField]
    private int _minMoneyReward;

    [SerializeField]
    private int _maxExpReward;
    [SerializeField]
    private int _minExpReward;

    private PlayerStats _playerStats;
    public bool orderTaken { get; private set; }
    
    private void Awake()
    {
        _orderIcon = Instantiate(_orderIcon, transform.position, Quaternion.identity);
        _orderIcon.transform.SetParent(transform);
        _playerStats = PlayerStats.Instance;
    }

    public void TakeReward()
    {
        if (!orderTaken)
        {
            _playerStats.AddMoney(OrderReward());
            _playerStats.AddExp(OrderReward());
            orderTaken = true;
            _orderIcon.SetActive(false);
        }
    }

    public void FallDown()
    {
        _orderIcon.SetActive(false);
    }


    private int OrderReward()
    {
        return Random.Range(_minMoneyReward, _minMoneyReward);
    }

    private int OrderRewardExp()
    {
        return Random.Range(_maxExpReward, _minExpReward);
    }
}
