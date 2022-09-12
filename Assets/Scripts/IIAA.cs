using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IIAA : MonoBehaviour
{
    [SerializeField]
    private float _delayBetwenVisitors = 2f;
    [SerializeField]
    private float _delayToVisitor = 2f;
    [SerializeField]
    private float _toStartPosDelay = 2f;

    private bool _servering = false;

    private Vector3 _startposition;

    
    public VisitorSpawner _spawner;

    private void Start()
    {
        
       
        _startposition = transform.position;
        
        StartCoroutine(ServeVisitors());
    }

    public void StartServing()
    {
        if (!_servering)
        {
            StartCoroutine(ServeVisitors());
        }

    }

    public void StopServing()
    {
        _servering = false;
    }


    IEnumerator ServeVisitors()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delayBetwenVisitors);

            

            if (_spawner.anyFreeVisitors())
            {
               
                

                Visitor vis = _spawner?.GetRandomVisitor();
                
                Vector3 vec = vis.transform.position;

                transform.position = vec;

                yield return new WaitForSeconds(_toStartPosDelay);

                transform.position = _startposition;

                yield return new WaitForSeconds(_delayToVisitor);

                transform.position = vec;

                vis?.GiveOrder();

                yield return new WaitForSeconds(_toStartPosDelay);

                transform.position = _startposition;


            }
            yield return new WaitForSeconds(_delayBetwenVisitors);

        }


    }
}
