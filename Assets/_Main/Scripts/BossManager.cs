using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BossManager : MonoBehaviour
{
    public GameObject Bullet;
    float fireRate;
    float nextFire;
    public Transform firePoint;
    public int health = 200;
    public CharacterInput target;
    public Vector2 moveDirection;
    private Animator animatorController;
    public string deadAnimation;
    public Animator animator;

    private void Awake()
    {
        animatorController = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)  //Daño que recibe el enemigo
    {
        health -= damage;
        if (health <= 0)
        {
            animator.SetBool("Death", true);
            Destroy(gameObject);    // Destrucción del enemigo
        }
        else
        {
            animatorController.SetTrigger("GetHit");
        }
    }
    void Start()
    {
        fireRate = 7f;
        nextFire = Time.time;
    }
    void Update()
    {
        CheckIfTimeToFire();
        
    }
    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            animator.SetBool("OnAttack", true);
            Instantiate(Bullet, firePoint.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }

    }
    
}


