using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOUR : PIECE
{
    

    public int FireRate;

    public GameObject bullet;
    public Transform canon, bouche;
    float chrono = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        chrono += Time.deltaTime;
        Transform target = ClosestEnemy();
        if(target != null)
        {
            canon.LookAt(target);
        }

        if(chrono > FireRate && target != null)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Shoot");

        if(bullet) Instantiate(bullet,bouche.position , canon.rotation);
        chrono = 0;
    }



    //Donne l'ennemi le plus proche (info)
    public Transform ClosestEnemy()
    {
        if(ENEMY.all.Count < 1) return null;
        Transform target = ENEMY.all[0].transform;

        for(int i = 0; i < ENEMY.all.Count; i ++)
        {
            if(Vector3.Distance(transform.position, target.position) > Vector3.Distance(transform.position, ENEMY.all[i].transform.position))
            {
                target = ENEMY.all[i].transform;
            }
        }
        return target;
    }


}//FIN CLASS TOUR

















