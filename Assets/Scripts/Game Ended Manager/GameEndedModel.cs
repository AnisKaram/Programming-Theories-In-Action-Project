using UnityEngine;

public class GameEndedModel : MonoBehaviour
{
    #region Fields
    [Header("Scripts")]
    [SerializeField] private GameEndedPresenter _gameEndedPresenter;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        TimerModel.OnTimerReachedZero += GameEnded;
    }

    private void OnDestroy()
    {
        TimerModel.OnTimerReachedZero -= GameEnded;
    }
    #endregion

    #region Private Methods
    private void GameEnded()
    {
        StopTheGame();
        _gameEndedPresenter.SetGameEndedCanvasVisibility();
    }

    private void StopTheGame()
    {
        Time.timeScale = 0;
    }
    #endregion
}