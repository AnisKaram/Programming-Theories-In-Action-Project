using UnityEngine;

/// <summary>
/// This class acts as the parent class for a fruit, it's used to
/// inherit from many child fruit classes.
/// *INHERITANCE, POLYMORPHYSM, ENCAPSULATION* are used in this script. 
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class FruitParent : MonoBehaviour
{
    #region Fields
    private Rigidbody2D _rigidbody2D;

    private Vector3 _eulerAngleVelocity;

    private Vector2 _screenBounds;

    private int _fruitScore;
    private float _movingSpeed;
    private float _rotationAngle;

    private bool _isObjectMoving;
    #endregion

    // ENCAPSULATION
    #region Properties
    public int FruitScore
    {
        get { return _fruitScore; }
    }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        GetScreenBounds();
        TransformScreenBoundsToNegative();
    }

    private void Start()
    {
        _eulerAngleVelocity = new Vector3(0, 0, _rotationAngle);
        MoveFruitDown();
    }

    private void Update()
    {
        if (_isObjectMoving)
        {
            if (transform.position.y < _screenBounds.y - 1)
            {
                RemoveObjectFromScene();
            }
        }
    }

    private void FixedUpdate()
    {
        if (_isObjectMoving)
        {
            RotateFruitWhileMovingDown();
        }
    }
    #endregion

    // POLYMORPHISM
    #region Protected Methods
    protected virtual void SetFruitScore(int score)
    {
        _fruitScore = score;
    }

    /// <summary>
    /// Set the moving value for the current fruit object.
    /// </summary>
    /// <param name="movingSpeed">Minimum of 100</param>
    protected virtual void SetMovingSpeed(float movingSpeed)
    {
        _movingSpeed = movingSpeed;
    }

    protected virtual void SetRotationAngle(float angle)
    {
        _rotationAngle = angle;
    }
    #endregion

    #region Private Methods
    private void MoveFruitDown()
    {
        _rigidbody2D.velocity = Vector2.down * _movingSpeed * Time.fixedDeltaTime;
        _isObjectMoving = true;
    }

    private void RotateFruitWhileMovingDown()
    {
        var deltaRotation = Quaternion.Euler(_eulerAngleVelocity * Time.fixedDeltaTime);
        _rigidbody2D.MoveRotation(gameObject.transform.rotation * deltaRotation);
    }

    private void GetScreenBounds()
    {
        _screenBounds = ScreenBoundsCalculatorUtil.CalculateScreenBounds();
    }

    private void TransformScreenBoundsToNegative()
    {
        _screenBounds = new Vector2(_screenBounds.x * -1, _screenBounds.y * -1);
    }

    private void RemoveObjectFromScene()
    {
        Destroy(gameObject);
    }
    #endregion
}