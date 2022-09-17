using UnityEngine;

public abstract class IItem : MonoBehaviour
{
    public abstract int isBuyed { get; }

    public abstract void Buy();

    public abstract void Render();
}
