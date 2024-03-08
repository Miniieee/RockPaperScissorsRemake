using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] Transform destinationPoint;
    [SerializeField] float speed;

    private bool isReachedDestination;

    // Start is called before the first frame update
    void Start()
    {
        destinationPoint = GameObject.FindGameObjectWithTag("EnemyDest").transform;
        isReachedDestination = false;
    }

    // Update is called once per frame
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
