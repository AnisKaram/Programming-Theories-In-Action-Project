using UnityEngine;

public class ObjectIdentifier : MonoBehaviour
{
    private void Awake()
    {
        InputManager.OnClickStarted += IdentifyObjectClicked;
    }

    private void OnDestroy()
    {
        InputManager.OnClickStarted -= IdentifyObjectClicked;
    }

    private void IdentifyObjectClicked(RaycastHit2D hit2D)
    {
        if (hit2D.transform != null && hit2D.collider.CompareTag("Fruit"))
        {
            FruitParent fruit = hit2D.transform.GetComponent<FruitParent>();
            Debug.Log($"Fruit name {fruit.name}, score {fruit.FruitScore}");
        }
    }
}
