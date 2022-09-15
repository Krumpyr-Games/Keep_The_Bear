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

    private void Start()
    {
        isSomeOneServeringVisitor = false;

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
        if(Random.Range(0 , 10) >= 1 && _orderGiven)
        {
            currentSpawnPoint.IsBusyTrue();
            var trash = Instantiate(_spawner.TrashPrefab, transform.position, Quaternion.identity);
            trash.GetComponent<Trash>().SetVisitor(currentSpawnPoint);
            trash.GetComponent<Trash>().SetVisitorPoint(this.GetComponent<Visitor>());
            LeaveVisitor();
        }
        else
        {
            currentSpawnPoint.IsBusyFalse();
            LeaveVisitor();
        }
    }
    public void LeaveVisitor()
    {       
        Destroy(gameObject);
    }

}
