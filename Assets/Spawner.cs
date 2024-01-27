using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    [SerializeField] private GameObject[] enemyObjects;
    [SerializeField] private float spawnSpeed = 1f;

    void Start()
    {
        
    }

    
    IEnumerator SpawnerLoop()
    {
        Instantiate()
        yield return new WaitForSeconds(spawnSpeed);
    }


}
