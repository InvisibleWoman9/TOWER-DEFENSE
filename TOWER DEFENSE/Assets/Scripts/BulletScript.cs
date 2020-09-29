using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public string target;
    public float damage;
    public float speed;
    public Rigidbody rb;

    void Start()
    {
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
        Destroy(gameObject, 5f);
    }


    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.transform.tag);
        if(col.transform.CompareTag(target))
        {
            col.transform.GetComponentInParent<PIECE>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }

}
