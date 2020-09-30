using System.Collections;
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
    public AudioClip tir;
    


    public void Awake()
    {
        destination = GameObject.Find("ARRIVEE").transform;
        all.Add(this.transform);
        agent.SetDestination(destination.position);
    }

    void OnDestroy()
    {
        GameManager.access.enemieskilled ++;
        if(GameManager.access.enemieskilled > GameManager.access.maxenemies)
        {
            GameManager.access.Victory();
        }
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
            AudioSource.PlayClipAtPoint(tir, Camera.main.transform.position, 0.05f);            
            Instantiate(bullet, canon.position, canon.rotation);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "ARRIVEE")
        {
            GameManager.access.GameOver();
            
        }
    }


}//FIN CLASS ENEMIES
















