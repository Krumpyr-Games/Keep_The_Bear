using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _toVisitorDelay = 2f;
    [SerializeField]
    private float _toVisitorDelay2 = 2f;

    [SerializeField]
    private float _toStartPosDelay  = 2f;

    Vector2 startPosion;
    Vector3 NewPosion;
    bool check = true;
    RaycastHit2D hit;

    Visitor _visitor;

    private int _FlipFlag;

    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        startPosion = transform.position;
    }

    void Update()
    {
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && Input.GetKey(KeyCode.Mouse0) && check && hit.collider.GetComponent<Visitor>())
        {
            NewPosion = hit.collider.transform.position;

            _visitor = hit.collider.GetComponent<Visitor>();

            StartCoroutine(ServeVisitor());

        }
    }

    public void SetFlip()
    {
      _spriteRenderer.flipX = true;  
    }

    public void ClearFlip()
    {
            _spriteRenderer.flipX = false;
    }

    IEnumerator ServeVisitor()
    {
        check = false;

        _visitor?.TakeOrder();

        yield return new WaitForSeconds(_toVisitorDelay);

        if (NewPosion.x <= 0) 
        {
            SetFlip();
        }

        transform.position = NewPosion;

        yield return new WaitForSeconds(_toStartPosDelay);

        ClearFlip();

        transform.position = startPosion;

        yield return new WaitForSeconds(_toVisitorDelay2);
        if (NewPosion.x <= 0)
        {
            SetFlip();
        }

        transform.position = NewPosion;

        if (!check)
        {
            _visitor?.GiveOrder();

            check = true;
        }
        

        yield return new WaitForSeconds(_toStartPosDelay);

        ClearFlip();
        transform.position = startPosion;
        //_visitor = null;

    }


}