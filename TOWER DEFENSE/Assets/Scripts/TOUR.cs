using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOUR : PIECE
{
    public static List<Transform> all = new List<Transform>();

    public int FireRate;
    public AudioClip tir;
    public GameObject bullet;
    public Transform canon, bouche;
    float chrono = 0;

    void Start()
    {
        
    }

    public void Awake()
    {
        all.Add(this.transform);
    }

    void OnDestroy()
    {
        all.Remove(this.transform);
    }
    
    void Update()
    {
        chrono += Time.deltaTime;
        Transform target = ClosestEnemy(ENEMY.all);
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

        if(bullet)
        {
            Instantiate(bullet,bouche.position , canon.rotation);
            AudioSource.PlayClipAtPoint(tir, Camera.main.transform.position, 0.2f);
        } 
        chrono = 0;
    }






}//FIN CLASS TOUR

















