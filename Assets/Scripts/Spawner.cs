using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Enemy objects")]
    [SerializeField] private GameObject[] enemyObjects;

    [Header("Shared Properties")]
    [SerializeField] private float spawnSpeed = 1f;
    [SerializeField] private int numberOfRounds;
    [SerializeField] private float timeOfShowingOrder;

    [Header("SpawnPoints")]
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Transform enemySpawnPoint;


    private List<GameObject> enemyOrder = new List<GameObject>();
    
    private List<GameObject> playerOrder = new List<GameObject>();

    private int decreaseableNumberOfRounds;
    private int numberOfPlayers;

    void Start()
    {
        decreaseableNumberOfRounds = numberOfRounds;
        numberOfPlayers = 0;
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
        StartCoroutine(ObjectSpawner());
    }

    IEnumerator ObjectSpawner()
    {
        for (int i = 0; i < enemyOrder.Count; i++)
        {
            Instantiate(enemyOrder[i], enemySpawnPoint.position, Quaternion.identity);

            if (numberOfPlayers > 0)
            {
                Instantiate(playerOrder[i], playerSpawnPoint.position, Quaternion.identity);
                numberOfPlayers--;
            }
            else
            {
                Debug.Log("You haven't picked one");
            }
            yield return new WaitForSeconds(spawnSpeed);
        }

        numberOfPlayers = 0;
        decreaseableNumberOfRounds = numberOfRounds;

        enemyOrder.Clear();
        playerOrder.Clear();
    }

    public void PlayerOrderInput(GameObject playerObject)
    {
        if (decreaseableNumberOfRounds > 0)
        {
            playerOrder.Add(playerObject);
            decreaseableNumberOfRounds--;
            numberOfPlayers++;
        }
        else
        {
            Debug.Log("reached the limit");
        }
    }
}
