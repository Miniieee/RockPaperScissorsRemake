using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject rockPlayer;
    [SerializeField] private GameObject paperPlayer;
    [SerializeField] private GameObject scissorPlayer;
    

    void Start()
    {
        
    }
/*
    
    public void ActivateRock()
    {   
        Instantiate(rockPlayer, transform.position, Quaternion.identity);
    }

    public void ActivatePaper()
    {
        Instantiate(paperPlayer, transform.position, Quaternion.identity);
    }

    public void ActivateScissors()
    {
       Instantiate(scissorPlayer, transform.position, Quaternion.identity);
    }*/
    
}
