using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Transform[] spawns;
    [SerializeField] private int waveAmount = 16;
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(waveAmount > 0)
        //{
        //    StartCoroutine(SpawnEnemy());
        //}
        //else
        //{
        //    gameManager.LoadGame();
        //}
    }

    IEnumerator SpawnEnemy()
    {
        //yield return new WaitForSeconds(2);
        //int random1 = Random.Range(0, spawns.Length);
        //int random2 = Random.Range(0, spawns.Length);
        //Instantiate(enemy, spawns[random1].position, enemy.transform.rotation);
        //Instantiate(enemy, spawns[random2].position, enemy.transform.rotation);
        //waveAmount -= 2;

    }
}
