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
}
