using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            

            if (!isItEnemy)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);

                string enemyTag = hit.collider.gameObject.tag;
                string playerTag = this.gameObject.tag;


                if (playerTag == "Rock")
                {
                    if (enemyTag == "EnemyPaper")
                    {
                        LostThisInstance(hit);
                    }

                    if (enemyTag == "EnemyScizzors")
                    {
                        WonThisInstance(hit);
                    }

                    if (enemyTag == "EnemyRock")
                    {
                        DrawThisInstance(hit);
                    }
                }

                if (playerTag == "Paper")
                {
                    if (enemyTag == "EnemyScizzors")
                    {
                        LostThisInstance(hit);
                    }

                    if (enemyTag == "EnemyRock")
                    {
                        WonThisInstance(hit);
                    }

                    if (enemyTag == "EnemyPaper")
                    {
                        DrawThisInstance(hit);
                    }
                }

                if (playerTag == "Scizzors")
                {
                    if (enemyTag == "EnemyRock")
                    {
                        LostThisInstance(hit);
                    }

                    if (enemyTag == "EnemyPaper")
                    {
                        WonThisInstance(hit);
                    }

                    if (enemyTag == "EnemyScizzors")
                    {
                        DrawThisInstance(hit);
                    }
                }              
           }

            //trigger an animation
        }
    }

    private void WonThisInstance(RaycastHit2D _hit)
    {
        Debug.Log("I've won");
        Destroy(_hit.collider.gameObject);
        Destroy(this.gameObject, 0.5f);
    }

    private void LostThisInstance(RaycastHit2D _hit)
    {
        Debug.Log("I've lost");

        Destroy(this.gameObject);
        Destroy(_hit.collider.gameObject, 0.5f);
    }

    private void DrawThisInstance(RaycastHit2D _hit)
    {
        Debug.Log("Draw");

        Destroy(this.gameObject);
        Destroy(_hit.collider.gameObject);
    }
}
