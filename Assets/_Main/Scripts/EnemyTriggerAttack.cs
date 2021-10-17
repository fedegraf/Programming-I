using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerAttack : MonoBehaviour
{
    [SerializeField] private float coolddown;
    private float timeBetweenAttacks;
    [SerializeField] private float tiempoDeAtaque;
    [SerializeField] private GameObject attackZone;
    [SerializeField] private GameObject EnemyOwner;
    private Animator Animador;
    private void Awake()
    {
        timeBetweenAttacks = 0;
        Animador = EnemyOwner.GetComponent<Animator>();
        attackZone.SetActive(false);
    }
    void Update()
    {
        timeBetweenAttacks += Time.deltaTime;
        if (attackZone.activeInHierarchy && timeBetweenAttacks > tiempoDeAtaque)
        {
            attackZone.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timeBetweenAttacks >= coolddown && collision.gameObject.CompareTag("Player"))
        {
            attackZone.SetActive(true);
            Animador.SetTrigger("onAttack");
            timeBetweenAttacks = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (timeBetweenAttacks >= coolddown && collision.gameObject.CompareTag("Player"))
        {
            attackZone.SetActive(true);
            Animador.SetTrigger("onAttack");
            timeBetweenAttacks = 0;
        }
    }
}
