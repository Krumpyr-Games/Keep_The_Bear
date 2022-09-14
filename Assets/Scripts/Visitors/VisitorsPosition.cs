using UnityEngine;
using UnityEngine.UIElements;

public class VisitorsPosition : MonoBehaviour
{
   
    private Visitor _visitor;
   
    #region Busy
    public bool IsBusy { get; private set; }

    public void IsBusyTrue()
    {
        IsBusy = true;
    }

    public void IsBusyFalse()
    {
        IsBusy = false;
    }

    #endregion

    #region Open-Close

 
    public void OnPoint()
    {
        gameObject.SetActive(true);
    }

    public void OffPoint()
    {
        gameObject.SetActive(false);
    }
    #endregion
    #region Inicialization 
    private void OnEnable()
    {
        EventMenager.OnSpawnVisitoPoint += IsBusyTrue;
        EventMenager.OffSpawnVisitoPoint += IsBusyFalse;
    }

    private void OnDisable()
    {
        EventMenager.OnSpawnVisitoPoint -= IsBusyTrue;
        EventMenager.OffSpawnVisitoPoint -= IsBusyFalse;
    }
    #endregion

    public void SetNewVisitor(Visitor newVisitor)
    {
        if (_visitor != null) return;
        
        _visitor = newVisitor;
    }

    public Visitor GetCurrentVisitor()
    {
        return _visitor;
    }


    
}
