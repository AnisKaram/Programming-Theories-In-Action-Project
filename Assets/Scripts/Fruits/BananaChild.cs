using UnityEngine;

public class BananaChild : FruitParent
{
    #region Unity Methods
    private void OnEnable()
    {
        SetFruitScore(2);
        SetMovingSpeed(150);
        SetRotationAngle(Random.Range(-90, -110));
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