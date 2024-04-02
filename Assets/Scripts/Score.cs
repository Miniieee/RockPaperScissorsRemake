using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Header("Health bars")]
    [SerializeField] Slider playerSlider;
    [SerializeField] Slider enemySlider;

    [Header("Healths")]
    [SerializeField] int playerHealth;
    [SerializeField] int enemyHealth;

/*
    [Header("Colors")]
    [SerializeField] private Color highHealth;
    [SerializeField] private Color midHealth;
    [SerializeField] private Color lowHealth;

*/
    
    void Start()
    {
        playerSlider.value = playerHealth;
        enemySlider.value = enemyHealth;
    }

    
    public void WonRound()
    {
        enemyHealth--;
        enemySlider.value = enemyHealth;

        HealthCheck();
    }

    public void LostRound()
    {
        playerHealth--;
        playerSlider.value = playerHealth;
        
        HealthCheck();
    }

    public void DrawRound()
    {
        enemyHealth--;
        enemySlider.value = enemyHealth;

        playerHealth--;
        playerSlider.value = playerHealth;
        
        HealthCheck();
    }

    private void HealthCheck()
    {
        if (playerHealth < 1 && enemyHealth < 1)
        {
            Debug.Log("Draw");
        }
        if (playerHealth < 1)
        {
            Debug.Log("Lost the game");
        }
        if (enemyHealth < 1)
        {
            Debug.Log("Won the game");
        }
    }
}
