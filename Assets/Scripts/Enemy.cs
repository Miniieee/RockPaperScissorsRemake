using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0f, 0f);
    }

    public void DestroyGameobject()
    {
        Destroy(gameObject);
    }

    public void SetSpeed(float _speed)
    {
        Debug.Log("it modified the speed");
        speed = _speed;
        
        //check which player is enabled
        

        //trigger some animation
    }
}
