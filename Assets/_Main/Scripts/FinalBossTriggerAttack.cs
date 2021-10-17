using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossTriggerAttack : MonoBehaviour
{
    [SerializeField] private float coolddown;
    public float timeBetweenAttacks;
    [SerializeField] private float attackTime = 2f;
    [SerializeField] private GameObject attackZone;
    [SerializeField] private GameObject EnemyOwner;
    private Animator Animador;
    private void Awake()
    {
        
        Animador = EnemyOwner.GetComponent<Animator>();
    }
    private void Start()
    {
        timeBetweenAttacks = 0;
        attackZone.SetActive(false);

    }
    void Update()
    {
        timeBetweenAttacks += Time.deltaTime;
        if (attackZone.activeInHierarchy && timeBetweenAttacks >= attackTime)
        {
            Animador.SetTrigger("OnAttack");
            attackZone.SetActive(false);
            Debug.Log("Me trigerea el ataque");
        }  
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (timeBetweenAttacks >= coolddown)
        {
            attackZone.SetActive(true);
           
            timeBetweenAttacks = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timeBetweenAttacks >= coolddown)
        {
            attackZone.SetActive(true);
            Animador.SetTrigger("OnAttack");
            timeBetweenAttacks = 0;
        }
    }
}
