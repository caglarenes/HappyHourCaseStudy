using UnityEngine;

public abstract class IView : MonoBehaviour
{
    public virtual void ChangeVisibility(bool isOpen) 
    {
        gameObject.SetActive(isOpen);
    }
}
