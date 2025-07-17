using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxX = 2.15f;
    public Transform spawnPoint;
    public float spawnRate = 1;
    public Text scoreText;
    public GameObject tapText;
    public GameObject titleText;

    bool gameStarted = false;
    int score = 0;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
            tapText.SetActive(false);
            titleText.SetActive(false);
        }
        //SpawnBlock();
    }

    private void StartSpawning()
    {
       InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(block, spawnPos, Quaternion.identity);
        score++;
        scoreText.text = score.ToString();
    }
}
