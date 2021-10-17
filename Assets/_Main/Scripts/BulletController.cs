using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    public LifeManager CharacterLife;
    [SerializeField] private float damage;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    } 
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter Bullet");
        CharacterInput player = collision.GetComponent<CharacterInput>();
        CharacterLife = collision.GetComponent<LifeManager>();
        if (player != null)
        {
            //Intenta sacarle vida al objeto con el que colisiono
            try
            {
                CharacterLife.GetDamage(damage);
            }
            catch
            {
                Debug.Log("Error al invocar GetDamage del player");
                Exception E;
            }

            Destroy(gameObject);
        }
    }
}