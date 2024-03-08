using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawnable objects array")]
    [SerializeField] private GameObject[] enemyObjects;

    [SerializeField] private float spawnSpeed = 1f;

    [SerializeField] private int numberOfRounds;
    [SerializeField] private float timeOfShowingOrder;

    private List<GameObject> enemyOrder = new List<GameObject>();

    void Start()
    {
        
        GenerateEnemyOrder();
    }

    private void GenerateEnemyOrder()
    {
        for (int i = 0; i < numberOfRounds; i++)
        {
            int generatedNum = 0;
            generatedNum = UnityEngine.Random.Range(0, 3);

            enemyOrder.Add(enemyObjects[generatedNum]);
        }

        //Debug.Log(enemyOrder.Count);
        Invoke("WaitAmountOfSeconds", timeOfShowingOrder);
    }

    private void WaitAmountOfSeconds()
    {
        //Debug.Log("waited 5 seconds");
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        
        foreach (GameObject spawnedObjects in enemyOrder)
        {
            Instantiate(spawnedObjects, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnSpeed);
        }

        enemyOrder.Clear();

    }
}
