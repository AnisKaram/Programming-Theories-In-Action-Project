using System;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This script is responsible for handling the timer in every round
/// and to call the UI update method(s) in the presenter.
/// </summary>
public class TimerModel : MonoBehaviour
{
    #region Fields
    [Header("Scripts")]
    [SerializeField] private TimerPresenter _timerPresenter;
    
    private float _timerInSeconds;
    private bool _isTimerReachedZero;
    #endregion

    #region Events
    public static event UnityAction OnTimerReachedZero;
    #endregion

    #region Unity Methods
    private void Start()
    {
        SetTimer();
        ConvertTimerInMinutesAndSecondsAndUpdateUI();
        StartTimer();
    }

    private void Update()
    {
        if (!_isTimerReachedZero)
        {
            UpdateTimerInSeconds();
        }
    }
    #endregion

    #region Private Methods
    private void UpdateTimerInSeconds()
    {
        if (_timerInSeconds > 0f)
        {
            _timerInSeconds -= 1 * Time.deltaTime;
            ConvertTimerInMinutesAndSecondsAndUpdateUI();
            return;
        }

        StopTimer();
        ResetTimer();
        ConvertTimerInMinutesAndSecondsAndUpdateUI();
        OnTimerReachedZero?.Invoke();
    }

    private void ConvertTimerInMinutesAndSecondsAndUpdateUI()
    {
        // Older version
        //float minutes = Mathf.FloorToInt(_timeInSeconds / 60);
        //float seconds = Mathf.FloorToInt(_timeInSeconds % 60);
        //float milliseconds = Mathf.FloorToInt(_timeInSeconds * 1000f);

        // .. newer version.
        TimeSpan timeSpan = TimeSpan.FromSeconds(_timerInSeconds);
        _timerPresenter.UpdateTimerTextOnUI(timeSpan);
    }

    private void StartTimer()
    {
        _isTimerReachedZero = false;
    }

    private void StopTimer()
    {
        _isTimerReachedZero = true;
    }

    private void SetTimer()
    {
        _timerInSeconds = UnityEngine.Random.Range(10, 15);
    }

    private void ResetTimer()
    {
        _timerInSeconds = 0;
    }
    #endregion
}