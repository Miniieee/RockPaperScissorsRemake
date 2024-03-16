using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] Transform destinationPoint;
    [SerializeField] float speed;
    [SerializeField] private bool isItEnemy;
    private bool isReachedDestination;



    void Start()
    {



        if (isItEnemy)
        {
            destinationPoint = GameObject.FindGameObjectWithTag("EnemyDest").transform;
        }
        else
        {
            destinationPoint = GameObject.FindGameObjectWithTag("PlayerDest").transform;
        }
    
        isReachedDestination = false;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinationPoint.transform.position,speed * Time.deltaTime);

        float distanceFromDestination = Vector2.Distance(transform.position, destinationPoint.position);

        if (distanceFromDestination < Mathf.Epsilon && !isReachedDestination)
        {
            isReachedDestination = true;
            Debug.Log("Reached dest");

            //trigger an animation

            
        }
    }
}
