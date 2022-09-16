using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Order))]
public class Visitor : MonoBehaviour
{
    public VisitorsPosition currentSpawnPoint;

    public bool isSomeOneServeringVisitor { get; private set; }

    [SerializeField]
    private float _waitingTime = 10f;

    [SerializeField]
    private float _timeBeforeDie = 4f;

    private Order _order;
    private bool _orderGiven = false;
    
    private BoxCollider2D _collider;

    private VisitorSpawner _spawner;
    private MoreVisitors _moreVisitors;

    [Header("Настройки грязного ивента")]
    [SerializeField] private int _maxRateTreashEvent;
    [SerializeField] private int _rateTreashEvent;


    [Header("Настройки праздник ивент")]
    [SerializeField] private int _maxRateMoreVisitorEvent;
    [SerializeField] private int _rateMoreVisitorEvent;

    private MoreVisitors moreVisitors;
    private void Start()
    {
        isSomeOneServeringVisitor = false;

        _moreVisitors = FindObjectOfType<MoreVisitors>().GetComponent<MoreVisitors>();
        _spawner = FindObjectOfType<VisitorSpawner>().GetComponent<VisitorSpawner>();

        _order = GetComponent<Order>();
        StartCoroutine(Life());
        _collider = GetComponent<BoxCollider2D>();
        
    }

    public void TakeOrder()
    {
        _collider.enabled = false;
        isSomeOneServeringVisitor = true;
    }




    public void GiveOrder()
    {
        TakeOrder();
        _order.TakeReward();
        _orderGiven = true;

        Invoke(nameof(OutOfTime),_timeBeforeDie);
    }


    IEnumerator Life()
    {
        yield return new WaitForSeconds(_waitingTime);

        
        _collider.enabled = false;

        if (isSomeOneServeringVisitor)
        {
            yield return new WaitUntil(() => _orderGiven == true);

        }
        else
        {
            
            Invoke(nameof(OutOfTime), _timeBeforeDie);
        }

    }


    private void OutOfTime()
    {

        StartMoreVisitorEvent();
        StartTreshEvents();
        LeaveVisitor();
    }


    public void StartTreshEvents() 
    {
        if (Random.Range(0, _maxRateTreashEvent) >= _rateTreashEvent && _orderGiven)
        {
            Debug.Log("Start event trash events in visitor script");
            currentSpawnPoint.IsBusyTrue();
            var trash = Instantiate(_spawner.TrashPrefab, transform.position, Quaternion.identity);
            trash.GetComponent<Trash>().SetVisitor(currentSpawnPoint);
            trash.GetComponent<Trash>().SetVisitorPoint(this.GetComponent<Visitor>());        
        }       
    }
    public void StartMoreVisitorEvent()
    {
        if (Random.Range(0, _maxRateMoreVisitorEvent) >= _rateMoreVisitorEvent && _orderGiven)
        {
            _moreVisitors.StartEventMoreVositor();
        }       
    }
    public void LeaveVisitor()
    {       
        Destroy(gameObject);
    }

}
