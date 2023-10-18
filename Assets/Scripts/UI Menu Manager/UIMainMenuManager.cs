using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIMainMenuManager : MonoBehaviour
{
    #region Fields
    [Header("Buttons")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _quitButton;

    private UnityAction _playAction;
    private UnityAction _quitAction;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        CreateButtonActions();
    }
    #endregion

    #region Private Methods
    private void CreateButtonActions()
    {
        _playAction = new UnityAction(() => { OnPlayButtonClicked(1); });
        _playButton.onClick.AddListener(_playAction);

        _quitAction = new UnityAction(OnQuitButtonClicked);
        _quitButton.onClick.AddListener(_quitAction);
    }

    private void OnPlayButtonClicked(int sceneIndex)
    {
        EnterScene(sceneIndex);
    }

    private void OnQuitButtonClicked()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void EnterScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }
    #endregion
}