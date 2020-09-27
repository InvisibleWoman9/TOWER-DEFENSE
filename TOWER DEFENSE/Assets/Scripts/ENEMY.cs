using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ENEMY : PIECE
{
    public static List<ENEMY> all = new List<ENEMY>();
    
    

    public float FireRate;

    public NavMeshAgent agent;
    public Transform destination;

    public void Awake()
    {
        destination = GameObject.Find("ARRIVEE").transform;
        all.Add(this);
        agent.SetDestination(destination.position);
    }

    void OnDestroy()
    {
        all.Remove(this);
    }

    public void Update()
    {

    }
    
    

    


}//FIN CLASS ENEMIES
















