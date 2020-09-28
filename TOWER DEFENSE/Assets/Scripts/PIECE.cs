using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIECE : MonoBehaviour
{
    public float Health;
    public bool IsAlive;

    void Start()
    {
        
    }


    public void TakeDamage(float Amount)
    {
        Health -= Amount;
        if(Health <= 0) Die();
    }


    void Die()
    {
        if(IsAlive == false) return;
        IsAlive = false;
        Destroy(gameObject);
    }

    //Donne l'ennemi le plus proche (info)
    public Transform ClosestEnemy(List<Transform> list)
    {
        if(list.Count < 1) return null;
        Transform target = list[0].transform;

        for(int i = 0; i < list.Count; i ++)
        {
            if(Vector3.Distance(transform.position, target.position) > Vector3.Distance(transform.position, list[i].transform.position))
            {
                target = list[i].transform;
            }
        }
        return target;
    }
}
