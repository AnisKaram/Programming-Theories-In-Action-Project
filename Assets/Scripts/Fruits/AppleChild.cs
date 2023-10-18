using UnityEngine;

public class AppleChild : FruitParent
{
    #region Unity Methods
    private void OnEnable()
    {
        SetFruitScore(1);
        SetMovingSpeed(100);
        SetRotationAngle(Random.Range(90, 120));
    }
    #endregion

    // POLYMORPHISM
    #region Overridden Methods
    protected override void SetFruitScore(int score)
    {
        base.SetFruitScore(score);
    }

    protected override void SetMovingSpeed(float movingSpeed)
    {
        base.SetMovingSpeed(movingSpeed);
    }

    protected override void SetRotationAngle(float angle)
    {
        base.SetRotationAngle(angle);
    }
    #endregion
}