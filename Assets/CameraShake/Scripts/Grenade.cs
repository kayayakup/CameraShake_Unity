using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField]
    private float delay = 3f;

    [SerializeField]
    private float radius = 150f;

    [SerializeField]
    private float force = 500f;

    [SerializeField]
    private GameObject explosionEffect;


    float countDown;
    public bool hasExploded;

    void Start()
    {
        countDown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

     public void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearByObjects in colliders)
        {
            Rigidbody rb = nearByObjects.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }
}
