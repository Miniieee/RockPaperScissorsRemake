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
}
