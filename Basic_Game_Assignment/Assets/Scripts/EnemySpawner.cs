using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Transform[] spawns;
    [SerializeField] private int waveAmount;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        waveAmount = gameManager.waveAmount;
        StartCoroutine(SpawnEnemy(waveAmount));
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    IEnumerator SpawnEnemy(int waveAmount)
    {
        yield return new WaitForSeconds(2);
        int random1 = Random.Range(0, spawns.Length);
        int random2 = Random.Range(0, spawns.Length);
        Instantiate(enemy, spawns[random1].position, spawns[random1].rotation);
        Instantiate(enemy, spawns[random2].position, spawns[random1].rotation);
        waveAmount -= 2;
        if(waveAmount > 0)
        {
            StartCoroutine(SpawnEnemy(waveAmount));
        }
        

    }
}
