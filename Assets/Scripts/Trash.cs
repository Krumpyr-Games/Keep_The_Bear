using UnityEngine;

public class Trash : MonoBehaviour
{
    private VisitorsPosition _visitorsPosition;

    private Visitor _visitor;
    private int _health = 3;

    private void OnMouseDown()
    {
        _health--;
        if(_health <= 0 )
        {
            Death();
        }
    }
    private void Death()
    {
        _visitorsPosition.IsBusyFalse();
        Destroy(gameObject);
        _visitor.LeaveVisitor();
    }
    public void SetVisitor(VisitorsPosition value)
    {
        _visitorsPosition = value;
    }
    public void SetVisitorPoint(Visitor value)
    {
        _visitor = value;
    }
}
