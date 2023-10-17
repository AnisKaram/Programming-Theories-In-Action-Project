using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private List<GameObject> _listOfFruitObjects;

    private Vector3 _screenBounds;

    private float yStartingPositon;
    private float yEndingPosition;
    private float xStartingPosition;
    private float xEndingPosition;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        _screenBounds = ScreenBoundsCalculatorUtil.CalculateScreenBounds();
        yStartingPositon = _screenBounds.y + 4f;
        yEndingPosition = _screenBounds.y + 2f;
        xStartingPosition = (_screenBounds.x * -1) + 2;
        xEndingPosition = xStartingPosition * -1;
    }

    private void Start()
    {
        StartCoroutine(SpawnFruitsCoroutine());
    }
    #endregion

    #region Private Methods
    private IEnumerator SpawnFruitsCoroutine()
    {
        int randomNumberOfFruitsToSpawn = Random.Range(1, _listOfFruitObjects.Count);
        for (int i = 0; i < randomNumberOfFruitsToSpawn; i++)
        {
            GameObject fruitSpawned = Instantiate(_listOfFruitObjects[Random.Range(0, _listOfFruitObjects.Count)]);
            float randomYValue = Random.Range(yStartingPositon, yEndingPosition);
            float randomXValue = Random.Range(xStartingPosition, xEndingPosition);
            fruitSpawned.transform.position = new Vector3(randomXValue, randomYValue);
            yield return new WaitForSeconds(Random.Range(0.25f, 0.5f));
        }
        yield return new WaitForSeconds(Random.Range(0.35f, 0.65f));
        StartCoroutine(SpawnFruitsCoroutine());
    }
    #endregion
}