using UnityEngine;

public abstract class Creator : MonoBehaviour
{
    public abstract IPopup FactoryMethod(Vector3 position);
}