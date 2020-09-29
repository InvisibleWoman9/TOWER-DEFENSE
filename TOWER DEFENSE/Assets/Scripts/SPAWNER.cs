using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPAWNER : MonoBehaviour
{
    public List<GameObject> enemies;
    public static int counter;
    float chrono, randomtime;
    

    public void Update()
    {
        chrono += Time.deltaTime;
        if(chrono > randomtime)
        {
            chrono = 0;
            randomtime = Random.Range(3f, 5f);
            Spawn();
        }
    }


    public void Spawn()
    {
        Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position, Quaternion.identity);
        counter ++;
        if(counter >= GameManager.access.maxenemies)
        {
            Destroy(this);
        }
    }
}
