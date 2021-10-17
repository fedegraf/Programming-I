using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossManager : MonoBehaviour
{
    public int health = 100;


    public void TakeDamage(int damage)  //Daño que recibe el enemigo
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);    // Destrucción del enemigo
        }
    }
}
