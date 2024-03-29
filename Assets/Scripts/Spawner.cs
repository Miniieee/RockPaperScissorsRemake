using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawner : MonoBehaviour
{
    [Header("Enemy objects")]
    [SerializeField] private GameObject[] enemyObjects;

    [Header("Enmey Sprites")]
    [SerializeField] private Sprite[] uISprites;

    [SerializeField] private GameObject enemyVisualParent;
    [SerializeField] private GameObject playerVisualParent;
    [SerializeField] private GameObject canvasToHide;

    [Header("Shared Properties")]
    [SerializeField] private float spawnSpeed = 1f;
    [SerializeField] private int numberOfRounds;
    [SerializeField] private float timeOfShowingOrder;

    [Header("SpawnPoints")]
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Transform enemySpawnPoint;

    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI timerText;

    private List<GameObject> enemyOrder = new List<GameObject>();
    
    private List<GameObject> playerOrder = new List<GameObject>();

    private Image[] enemyVisualsUI;
    private Image[] playerVisualsUI;


    private int decreaseableNumberOfRounds;
    private int numberOfPlayers;

    private bool isGenerated = false;
    private bool isPlayerCanSelect = true;
    private float timerOfEnemySprites = 5f;


    void Start()
    {
        decreaseableNumberOfRounds = numberOfRounds;
        numberOfPlayers = 0;
        ResetTimer();

        GenerateEnemyOrder();
    }

    private void Update() 
    {
        if (isGenerated)
        {   
            timerOfEnemySprites -= Time.deltaTime;

            timerText.text = timerOfEnemySprites.ToString("0");

            if (timerOfEnemySprites < Mathf.Epsilon)
            {
                isGenerated = false;
                canvasToHide.SetActive(false);
                isPlayerCanSelect = false;
                //show player panel
            }
        }
    }

    private void GenerateEnemyOrder()
    {
        enemyVisualsUI = enemyVisualParent.GetComponentsInChildren<Image>();
        playerVisualsUI = playerVisualParent.GetComponentsInChildren<Image>();

        foreach (Image playerSprites in playerVisualsUI)
        {
            playerSprites.sprite = null;
        }


        for (int i = 0; i < numberOfRounds; i++)
        {
            int generatedNum = 0;
            generatedNum = UnityEngine.Random.Range(0, 3);

            enemyOrder.Add(enemyObjects[generatedNum]);

            enemyVisualsUI[i].sprite = uISprites[generatedNum];
        }

        isGenerated = true;
        isPlayerCanSelect = true;

        ResetTimer();

        Invoke("WaitAmountOfSeconds", timeOfShowingOrder);
        
    }

    private void ResetTimer()
    {
        timerOfEnemySprites = timeOfShowingOrder;
    }

    private void WaitAmountOfSeconds()
    {
        StartCoroutine(ObjectSpawner());
    }

    IEnumerator ObjectSpawner()
    {
        for (int i = 0; i < enemyOrder.Count; i++)
        {
            Instantiate(enemyOrder[i], enemySpawnPoint.position, Quaternion.identity);

            if (numberOfPlayers > 0)
            {
                Instantiate(playerOrder[i], playerSpawnPoint.position, Quaternion.identity);
                numberOfPlayers--;
            }
            else
            {
                Debug.Log("You haven't picked one");
            }
            yield return new WaitForSeconds(spawnSpeed);
        }

        numberOfPlayers = 0;
        decreaseableNumberOfRounds = numberOfRounds;

        enemyOrder.Clear();
        playerOrder.Clear();
    }

    public void PlayerOrderInput(GameObject playerObject)
    {
        if (decreaseableNumberOfRounds > 0 && isPlayerCanSelect)
        {
            playerOrder.Add(playerObject);
            decreaseableNumberOfRounds--;
            int index = playerObject.GetComponent<ObjectMover>().index;

            playerVisualsUI[numberOfPlayers].sprite = uISprites[index];

            numberOfPlayers++;
        }
        else
        {
            Debug.Log("reached the limit");
        }
    }
}
