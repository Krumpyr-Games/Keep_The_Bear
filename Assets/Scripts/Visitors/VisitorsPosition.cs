using UnityEngine;

public class VisitorsPosition : MonoBehaviour
{
    private Visitor _visitor;

    public bool IsBusy { get; private set; }






    public void SetNewVisitor(Visitor newVisitor)
    {
        if (_visitor != null) return;
        
        _visitor = newVisitor;
    }

    public Visitor GetCurrentVisitor()
    {
        return _visitor;
    }


    public void IsBusyTrue()
    {
        IsBusy = true;
    }

    public void IsBusyFalse()
    {
        IsBusy = false;
    }

}
