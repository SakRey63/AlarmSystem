using System;
using UnityEngine;

public class TriggerZona : MonoBehaviour
{
    public event Action<GameObject> ObjectEntered;
    public event Action<GameObject> ObjectOut;
    
    private void OnTriggerEnter(Collider other)
    {
        ObjectEntered?.Invoke(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        ObjectOut?.Invoke(other.gameObject);
    }
}
