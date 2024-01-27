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
        rockPlayer.SetActive(true);
        paperPlayer.SetActive(false);
        scissorPlayer.SetActive(false);
    }


    void Update()
    {
        
    }

    public void ActivateRock()
    {   
        rockPlayer.SetActive(true);
        paperPlayer.SetActive(false);
        scissorPlayer.SetActive(false);
    }

    public void ActivatePaper()
    {
        rockPlayer.SetActive(false);
        paperPlayer.SetActive(true);
        scissorPlayer.SetActive(false);
        
    }

    public void ActivateScissors()
    {
        rockPlayer.SetActive(false);
        paperPlayer.SetActive(false);
        scissorPlayer.SetActive(true);
    }
}
