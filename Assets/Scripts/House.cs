using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarm;
    [SerializeField] private TriggerZona _zona;

    private bool _isEntrance;

    private void OnEnable()
    {
        _zona.ObjectEntered += WasEntry;
        _zona.ObjectOut += WasOut;
    }

    private void OnDisable()
    {
        _zona.ObjectEntered -= WasEntry;
        _zona.ObjectOut -= WasOut;
    }
    
    private void WasEntry (GameObject obj)
    {
        if (obj.TryGetComponent<Zombie>(out _))
        {
            _alarm.OnAlarm();
        }
    }

    private void WasOut(GameObject obj)
    {
        if (obj.TryGetComponent<Zombie>(out _))
        {
            _alarm.OffAlarm();
        }
    }
}
