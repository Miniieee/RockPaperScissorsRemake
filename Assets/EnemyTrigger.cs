using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Enemy triggeredEnemy = other.gameObject.GetComponent<Enemy>();

        triggeredEnemy.SetSpeed(0f);

        Debug.Log("enemy hit me");
    }
}
