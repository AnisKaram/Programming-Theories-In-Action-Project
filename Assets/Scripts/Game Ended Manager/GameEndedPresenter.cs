using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndedPresenter : MonoBehaviour
{
    [SerializeField] private ScoreModel _scoreModel;

    [SerializeField] private GameObject _gameEndedCanvas;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;

    private UnityAction _restartAction;
    private UnityAction _mainMenuAction;

    private void Awake()
    {
        CreateButtonActions();
    }

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

    public void SetGameEndedCanvasVisibility()
    {
        SethighScoreText();
        _gameEndedCanvas.SetActive(true);
    }

    private void SethighScoreText()
    {
        _highScoreText.text = $"High Score: {_scoreModel._highScore}";
    }
}
