using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackZone : MonoBehaviour
{

   private bool estoyAtacando;
   public EnemyManager enemy; 
   [SerializeField] private float damage;
   public FinalBossEnemyManager finalBoss;

   private void Awake()
    {
        estoyAtacando = false;
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerEnter Attack Zone Player");
        eventoAtaque(collision);
    }
   private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerStay Attack Zone Player");
        if (!estoyAtacando)
        {
            //Debug.Log("Ataque en OnTriggerStay");
            eventoAtaque(collision);            
        }
    }
   private void OnEnable()
   {
       //Setea que no esta atacando cada vez que se activa
        //Debug.Log("OnEnable");
        estoyAtacando = false;
    }
   private void eventoAtaque(Collider2D collision)
   {
       estoyAtacando = true;
       enemy = collision.GetComponent<EnemyManager>();
       finalBoss = collision.GetComponent<FinalBossEnemyManager>();
       PalancaController palancaController = collision.GetComponent<PalancaController>();
       if (enemy != null)
       {
           //Intenta sacarle a la vida a lo que choco
           try
           {
               enemy.GetDamage(damage);
           }
           catch
           {
               //Debug.Log("Error en el evento Ataque del player");
               //Exception E;
           }
       }
       else if (palancaController != null)
       {
           palancaController.ActivaEscalera();
       }
       Debug.Log(finalBoss);
       if (finalBoss != null)
       {
           try
           {
               Debug.Log("intenta hacerle daño");
               finalBoss.GetDamage(damage);

           }
           catch
           {
               Debug.Log("intenta hacerle daño parte del catch");
           }
       }
   }
}