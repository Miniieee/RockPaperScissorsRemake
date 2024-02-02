using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    [SerializeField] private GameObject[] enemyObjects;
    [SerializeField] private float spawnSpeed = 1f;

    void Start()
    {
        StartCoroutine(SpawnerLoop());
    }

    
    IEnumerator SpawnerLoop()
    {

        while (true)
        {
            int generatedNum = 0;

            generatedNum = Random.Range(0,3);
        
            Instantiate(enemyObjects[generatedNum], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnSpeed);
        }
        
    }


}
