using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    #region Fields
    private InputActions _inputActions;
    private Camera _mainCamera;
    #endregion

    #region Events
    public static event UnityAction<RaycastHit2D> OnClickStarted;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        _mainCamera = Camera.main;
        CreateInputActionObject();
        EnableInputAction();

        TimerModel.OnTimerReachedZero += DisableInputAction;
        _inputActions.MouseMap.Click.started += _ => Click_Started();
        _inputActions.MouseMap.Click.canceled += _ => Click_Canceled(); 
    }

    private void OnDestroy()
    {
        DisableInputAction();

        TimerModel.OnTimerReachedZero -= DisableInputAction;
        _inputActions.MouseMap.Click.started -= _ => Click_Started();
        _inputActions.MouseMap.Click.canceled -= _ => Click_Canceled();
    }
    #endregion

    // ABSTRACTION
    #region Private Methods
    private void CreateInputActionObject()
    {
        _inputActions = new InputActions();
    }

    private void EnableInputAction()
    {
        _inputActions.MouseMap.Enable();
    }

    private void DisableInputAction()
    {
        _inputActions.MouseMap.Disable();
    }

    private void Click_Started()
    {
        Vector2 clickPosition = _inputActions.MouseMap.Click.ReadValue<Vector2>();
        Vector2 clickWorldPosition = _mainCamera.ScreenToWorldPoint(clickPosition);
        RaycastHit2D hit2D = Physics2D.Raycast(clickWorldPosition, Vector2.zero, 1);
        OnClickStarted?.Invoke(hit2D);
    }

    private void Click_Canceled()
    {
        //Debug.Log($"Click canceled");
    }
    #endregion
}