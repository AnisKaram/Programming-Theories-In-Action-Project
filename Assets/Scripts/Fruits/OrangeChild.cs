using UnityEngine;

public class OrangeChild : FruitParent
{
    #region Unity Methods
    private void OnEnable()
    {
        SetFruitScore(2);
        SetMovingSpeed(250);
        SetRotationAngle(Random.Range(-180, -220));
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
