using UnityEngine;

public class MangoChild : FruitParent
{
    #region Unity Methods
    private void OnEnable()
    {
        SetFruitScore(6);
        SetMovingSpeed(400);
        SetRotationAngle(Random.Range(90f, 110f));
    }
    #endregion

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