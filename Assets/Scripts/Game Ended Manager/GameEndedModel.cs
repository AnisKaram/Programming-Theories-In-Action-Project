using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndedModel : MonoBehaviour
{
    [SerializeField] private GameEndedPresenter _gameEndedPresenter;

    private void Awake()
    {
        TimerModel.OnTimerReachedZero += GameEnded;
    }

    private void OnDestroy()
    {
        TimerModel.OnTimerReachedZero -= GameEnded;
    }

    private void GameEnded()
    {
        StopTheGame();
        _gameEndedPresenter.SetGameEndedCanvasVisibility();
    }

    private void StopTheGame()
    {
        Time.timeScale = 0;
    }
}
