using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Vetor que guarada os possiveis obstaculos
    public GameObject[] obstaclePrefabs = new GameObject[3];
    public float startDelay = 2;
    public float repeatRate = 2;
    private Vector3 spawnPos = new Vector3(15, 0, 0);
    private PlayerController playerControllerScript;
    void Start()
    {
        //spawna os obstaculos na tela chamando o metodo SpawnObstacle()
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
    }

    // Método para gerenciamento do spawn de obstáculos, a cada 15 unidades de distância do início da fase
    void SpawnObstacle()
    {
        //Spawna obstaculos de forma aleatoria durante o game
        if (obstaclePrefabs != null && obstaclePrefabs.Length > 0 && playerControllerScript.gameOver == false)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, Quaternion.identity);
        }
    }
}
