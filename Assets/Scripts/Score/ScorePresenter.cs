using UnityEngine;
using TMPro;
using System.Collections;

/// <summary>
/// This script acts as the presenter to update the score on UI once updated in the model.
/// *ABSTRACTION* used.
/// </summary>
public class ScorePresenter : MonoBehaviour
{
    #region Fields
    [Header("Texts - TextMeshPro")]
    [SerializeField] private TextMeshProUGUI _scoreText;

    private WaitForSecondsRealtime _waitForPointZeroFiveSeconds;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        _waitForPointZeroFiveSeconds = new WaitForSecondsRealtime(0.05f);
    }
    #endregion

    // ABSTRACTION.
    #region Public Methods
    /// <summary>
    /// This method starts a coroutine to update the score incrementally.
    /// </summary>
    /// <param name="previousScore">Previous score before updating</param>
    /// <param name="currentScore">Current updated score</param>
    public void CallUpdateScoreOnUI(int previousScore, int currentScore)
    {
        StartCoroutine(UpdateScoreOnUICoroutine(previousScore, currentScore));
    }

    /// <summary>
    /// This method is used to update the score text on the UI canvas.
    /// </summary>
    /// <param name="score">Score to show on the score text</param>
    public void UpdateScoreOnUI(int score)
    {
        _scoreText.text = $"Score: {score}";
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// This coroutine method is used to update the score incrementally
    /// each 0.05f seconds.
    /// </summary>
    private IEnumerator UpdateScoreOnUICoroutine(int previousScore, int currentScore)
    {
        int previous = previousScore;
        while (previous < currentScore)
        {
            previous += 1;
            UpdateScoreOnUI(previous);
            yield return _waitForPointZeroFiveSeconds;
        }
    }
    #endregion
}