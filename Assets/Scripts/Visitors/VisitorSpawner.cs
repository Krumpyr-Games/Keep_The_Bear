using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorSpawner : MonoBehaviour
{
    [SerializeField] 
    VisitorsPosition[] _points = {};
    [SerializeField] 
    GameObject[] VisitorsSkinArr = { };
    [SerializeField]
    private float _spawnRate;

    private void Start()
    {
        StartCoroutine(SpawnVisitors());
    }

    IEnumerator SpawnVisitors()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);
            if (anyFreePoint())
            {
                VisitorsPosition pos = RandomPoint();

                if (pos != null)
                {
                    InstantiateVisitors(pos);
                }

                yield return new WaitForEndOfFrame();
            }
        }
        
    }

    public VisitorsPosition RandomPoint()
    {
        List<VisitorsPosition> positions = new List<VisitorsPosition>();

        for (int i = 0; i < _points.Length; i++)
        {
            if (!_points[i].IsBusy && _points[i].isActiveAndEnabled)
            {
                positions.Add(_points[i]);
            }
        }


        if(!(positions.Count == 0))
        {
            return positions[Random.Range(0, positions.Count)];
        }

        return null;

    }

    public bool anyFreePoint()
    {

        for (int i = 0; i < _points.Length; i++)
        {
            if (!_points[i].IsBusy && isActiveAndEnabled)
            {
                return true;
            }
        }

        return false;
    }


    public Visitor GetRandomVisitor()
    {
        List<Visitor> visitors = GetFreeVisitorsList();

        List<Visitor> freeVisitors = new List<Visitor>();
        
        for (int i = 0; i < visitors.Count; i++)
        {
            if (!visitors[i].isSomeOneServeringVisitor)
            {
                freeVisitors.Add(visitors[i]);
            }
        }

        int index = Random.Range(0,freeVisitors.Count);
        freeVisitors[index]?.TakeOrder();
        

        return freeVisitors[index];

    }

    public bool anyFreeVisitors()
    {
        List<Visitor> visitors = GetFreeVisitorsList();


        for (int i = 0; i < visitors.Count; i++)
        {
            if (!visitors[i].isSomeOneServeringVisitor)
            {
                return true;
            }
        }

        return false;
    }

    private List<Visitor> GetFreeVisitorsList()
    {

        List<Visitor> visitors = new List<Visitor>();

        for (int i = 0; i < _points.Length; i++)
        {
            if (_points[i].IsBusy)
            {
                visitors.Add(_points[i].GetCurrentVisitor());
            }
        }


        return visitors;
    }

    


    private void InstantiateVisitors(VisitorsPosition spawnPointPosition)
    {
        
        spawnPointPosition.IsBusyTrue();

        int index = Random.Range(0, VisitorsSkinArr.Length);
        var spawnedVisitor = Instantiate(VisitorsSkinArr[index], spawnPointPosition.transform.position, Quaternion.identity);

        Visitor vis = spawnedVisitor.GetComponent<Visitor>();
      
        vis.currentSpawnPoint = spawnPointPosition;

        spawnPointPosition.SetNewVisitor(vis);

    }


}
