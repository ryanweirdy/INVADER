using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Alien enemy = other.GetComponent<Alien>();

        if (enemy != null)
        {
           // enemy.TakeDamage();
            Destroy(gameObject);
        }
    }
}