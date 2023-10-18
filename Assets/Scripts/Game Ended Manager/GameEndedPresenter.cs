using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndedPresenter : MonoBehaviour
{
    #region Fields
    [Header("Scripts")]
    [SerializeField] private ScoreModel _scoreModel;

    [Header("GameObjects")]
    [SerializeField] private GameObject _gameEndedCanvas;

    [Header("Texts - TextMeshPro")]
    [SerializeField] private TextMeshProUGUI _highScoreText;

    [Header("Buttons")]
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;

    private UnityAction _restartAction;
    private UnityAction _mainMenuAction;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        CreateButtonActions();
    }
    #endregion

    #region Public Methods
    public void SetGameEndedCanvasVisibility()
    {
        SethighScoreText();
        _gameEndedCanvas.SetActive(true);
    }
    #endregion

    #region Private Methods
    private void CreateButtonActions()
    {
        _restartAction = new UnityAction(OnRestartButtonClicked);
        _restartButton.onClick.AddListener(_restartAction);

        _mainMenuAction = new UnityAction(OnMainMenuButtonClicked);
        _mainMenuButton.onClick.AddListener(_mainMenuAction);
    }

    private void OnRestartButtonClicked()
    {
        EnterScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnMainMenuButtonClicked()
    {
        EnterScene(0);
    }

    private void EnterScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    private void SethighScoreText()
    {
        _highScoreText.text = $"High Score: {_scoreModel._highScore}";
    }
    #endregion
}