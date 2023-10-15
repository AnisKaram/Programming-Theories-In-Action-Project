using UnityEngine;

/// <summary>
/// In this script we are calculating the screen bounds in vector3 units.
/// Static class is used as ABSTRACTION.
/// </summary>
public static class ScreenBoundsCalculatorUtil
{
    // ABSTRACTION
    #region Public Methods
    public static Vector3 CalculateScreenBounds()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    #endregion
}