using UnityEngine;
using UnityEngine.Events;

public class ObjectIdentifier : MonoBehaviour
{
    public static event UnityAction<int> OnScoreFetched;
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
            OnScoreFetched?.Invoke(fruit.FruitScore);
            Destroy(fruit.gameObject);
        }
    }
}
