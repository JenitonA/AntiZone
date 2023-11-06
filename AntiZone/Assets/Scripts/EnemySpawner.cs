using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 WATCH THIS VIDEO: https://www.youtube.com/watch?v=SELTWo1XZ0c&ab_channel=ModdingbyKaupenjoe
*/



public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy1;

    [SerializeField]
    private float rate = 2;

    
    Vector2 getPosition()
    {
        var position = new Vector2(Random.Range(-20.0f, 20.0f), Random.Range(-18.0f, 18.0f)); // Will find a random position on the map
        return position;
    }
    
    private IEnumerator spawnEnemy(float rate, GameObject enemy)
    {
        //Rigidbody2D rb = enemy1.GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(rate);
        GameObject newEnemy = Instantiate(enemy, getPosition(), Quaternion.identity); // spawns enemy
        StartCoroutine(spawnEnemy(rate, enemy));
    }
    



    // FIX SPAWNING. IT SPAWNS WAY TOO MANY AT THE SAME TIME
    //void Update()
    //{
    //    if (Time.time > canSpawn)
    //    {
    //        Debug.Log("SPAWNED");
    //        spawnEnemy();
    //        canSpawn = Time.time + spawnRate;
    //    }
    //}

    void Start()
    {
        StartCoroutine(spawnEnemy(rate, enemy1));
    }
}
