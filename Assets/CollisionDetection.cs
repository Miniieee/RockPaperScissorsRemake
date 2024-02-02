using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "RockEnemy")
        {
            other.GetComponent<Enemy>().DestroyGameobject();
        }
        
    }
}
