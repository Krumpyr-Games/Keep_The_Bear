using System.Collections;
using UnityEngine;
using static TrashEvent;
using static Visitor;

[RequireComponent(typeof(Order))]
public class Visitor : MonoBehaviour
{
    public delegate void AfterDead(Transform transform);
    public static event AfterDead AfterDea;



    public VisitorsPosition currentSpawnPoint;

    public bool isSomeOneServeringVisitor { get; private set; }

    [SerializeField]
    private float _waitingTime = 10f;

    [SerializeField]
    private float _timeBeforeDie = 4f;

    private Order _order;
    private bool _orderGiven = false;


    private BoxCollider2D _collider;

    private void Start()
    {
        isSomeOneServeringVisitor = false;

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
        currentSpawnPoint.IsBusyFalse();
        AfterDea(gameObject.transform);   
        Destroy(gameObject);
    }

}
