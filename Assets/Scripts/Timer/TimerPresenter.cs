using UnityEngine;
using TMPro;
using System;

/// <summary>
/// This script is responsible for updating the UI for the timer text
/// whenever it gets updated/called.
/// </summary>
public class TimerPresenter : MonoBehaviour
{
    #region Fields
    [SerializeField] private TextMeshProUGUI _timerText;
    #endregion

    #region Public Methods
    public void UpdateTimerTextOnUI(TimeSpan timeSpan)
    {
        //_timerText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
        _timerText.text = timeSpan.ToString("mm\\:ss\\:ff");
    }
    #endregion
}