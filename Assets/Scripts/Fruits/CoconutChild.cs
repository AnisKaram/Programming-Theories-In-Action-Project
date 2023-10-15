using UnityEngine;

public class CoconutChild : FruitParent
{
    #region Unity Methods
    private void OnEnable()
    {
        SetFruitScore(5);
        SetMovingSpeed(300);
        SetRotationAngle(Random.Range(300, 360));
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