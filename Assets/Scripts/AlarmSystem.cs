using System.Collections;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _minVolume = 0;
    [SerializeField] private float _maxVolume = 1;
    [SerializeField] private float _speedCangeSound;
    [SerializeField] private float _delay = 0.5f;

    private Coroutine _coroutine;
    
    private void Start()
    {
        _audioSource.volume = _minVolume;
    }
    
    private IEnumerator ChangeVolume(float targetVolume)
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        float trackSpeed = _maxVolume / _speedCangeSound;

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, trackSpeed);

            yield return delay;
        }

        if (_audioSource.volume <= _minVolume)
        {
            _audioSource.Stop();
        }
    }
    
    public void OnAlarm()
    {
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();
        }

        SetVolume(_maxVolume);
    }

    public void OffAlarm()
    {
        SetVolume(_minVolume);
    }
    
    private void SetVolume(float volume)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeVolume(volume));
    }
}
