﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ENEMY : PIECE
{
    public static List<Transform> all = new List<Transform>();
    
    

    public float FireRate, portee;
    float chrono;
    public NavMeshAgent agent;
    public Transform destination, canon;
    public GameObject bullet;


    public void Awake()
    {
        destination = GameObject.Find("ARRIVEE").transform;
        all.Add(this.transform);
        agent.SetDestination(destination.position);
    }

    void OnDestroy()
    {
        all.Remove(this.transform);
    }

    public void Update()
    {
        chrono += Time.deltaTime;
        if(chrono > FireRate)
        {
            chrono = 0;
            Shoot();

        }


    }
    
    public void Shoot()
    {
        Transform target = ClosestEnemy(TOUR.all);
        if(target != null && Vector3.Distance(transform.position, target.position) < portee)
        {
            canon.LookAt(target.Find("GRAPHICS/CANON"));
            Debug.Log(target);
            Instantiate(bullet, canon.position, canon.rotation);
        }
    }

    


}//FIN CLASS ENEMIES
















