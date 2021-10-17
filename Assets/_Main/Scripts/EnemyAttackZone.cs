using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttackZone : MonoBehaviour
{
    public LifeManager playerlife; 
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        eventoAtaque(collision);
    }
/*    private void OnTriggerStay2D(Collider2D collision)
    {
        eventoAtaque(collision);
    }
*/
    private void eventoAtaque(Collider2D collision)
    {
        playerlife = collision.GetComponent<LifeManager>();
        if (playerlife != null)
        {
            try
            {
                playerlife.GetDamage(damage);
            }
            catch
            {
                Debug.Log("Error al invocar GetDamage del Player");
                Exception E;
            }
        }
    }
}