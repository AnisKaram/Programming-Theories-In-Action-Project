using UnityEngine;

/// <summary>
/// This script acts as the score model in which it stores the current score and
/// calls the appropriate method(s) in the presenter.
/// </summary>
public class ScoreModel : MonoBehaviour
{
    #region Fields
    [SerializeField] private ScorePresenter _scorePresenter;

    private int _currentScore = 0;
    private int _previousScore = 0;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        ObjectIdentifier.OnScoreFetched += IncrementScore;
    }

    private void Start()
    {
        _scorePresenter.UpdateScoreOnUI(_currentScore);
    }

    private void OnDestroy()
    {
        ObjectIdentifier.OnScoreFetched -= IncrementScore;
    }
    #endregion

    #region Private Methods
    private void IncrementScore(int score)
    {
        _previousScore = _currentScore;
        _currentScore += score;
        _scorePresenter.CallUpdateScoreOnUI(_previousScore, _currentScore);
    }
    #endregion
}