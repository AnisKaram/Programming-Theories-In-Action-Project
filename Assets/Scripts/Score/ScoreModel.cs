using UnityEngine;

/// <summary>
/// This script acts as the score model in which it stores the current score and
/// calls the appropriate method(s) in the presenter.
/// </summary>
public class ScoreModel : MonoBehaviour
{
    #region Fields
    [Header("Scripts")]
    [SerializeField] private ScorePresenter _scorePresenter;

    public int _highScore { get; private set; }
    private int _currentScore = 0;
    private int _previousScore = 0;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        ObjectIdentifier.OnScoreFetched += IncrementScore;

        _highScore = LoadHighScore();
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
        CheckOnCurrentAndHighScores();
        _scorePresenter.CallUpdateScoreOnUI(_previousScore, _currentScore);
    }

    private void CheckOnCurrentAndHighScores()
    {
        if (IsCurrentScoreSurpassedHighScore())
        {
            _highScore = _currentScore;
            SaveHighScore();
        }
    }

    private bool IsCurrentScoreSurpassedHighScore()
    {
        if (_currentScore > _highScore)
        {
            return true;
        }
        return false;
    }

    private int LoadHighScore()
    {
        if (PlayerPrefs.HasKey("{h.val}"))
        {
            return PlayerPrefs.GetInt("{h.val}", 0);
        }
        return 0;
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("{h.val}", _highScore);
    }
    #endregion
}