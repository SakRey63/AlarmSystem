using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlarmSystem _alarm;

    private bool _isEntrance;

    private void OnEnable()
    {
        _alarm.ObjectEntered += WasEntry;
        _alarm.ObjectOut += WasOut;
    }

    private void OnDisable()
    {
        _alarm.ObjectEntered -= WasEntry;
        _alarm.ObjectOut -= WasOut;
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
