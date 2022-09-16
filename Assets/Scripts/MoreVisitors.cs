using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoreVisitors : MonoBehaviour
{
    [SerializeField] private float _reatMoreVisitorEvent;

    [SerializeField] private int _vaitingTime;

    [SerializeField] private GameObject _UIMoreVisitorEvent;

    private VisitorSpawner visitorSpawner;
   public void StartEventMoreVositor()
    {
        visitorSpawner = FindObjectOfType<VisitorSpawner>().GetComponent<VisitorSpawner>();
        Debug.Log("Start event more event");   
        StartCoroutine(EventMoreVisitor());
    }

    private  IEnumerator EventMoreVisitor()
    {
        _UIMoreVisitorEvent.SetActive(true);
        yield return new WaitUntil(() => _UIMoreVisitorEvent.activeSelf == false);
        float StaticRate = visitorSpawner._spawnRate;
        visitorSpawner._spawnRate = _reatMoreVisitorEvent;
        yield return new WaitForSeconds(_vaitingTime);
        visitorSpawner._spawnRate = StaticRate;
    }

    public void Test()
    {
       
    }

}
