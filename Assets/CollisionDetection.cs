using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {

        if (gameObject.tag == other.gameObject.tag)
        {
            other.GetComponent<Enemy>().DestroyGameobject();
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("died");
        }
        
    }
}
