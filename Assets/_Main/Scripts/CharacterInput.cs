using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterInput : MonoBehaviour
{

    [SerializeField] private float speed = 1;
    [SerializeField] private bool lookFront = true;
    private bool isAlive;
    private Animator animatorController;
    [SerializeField] private GameObject attackZone;
    [SerializeField] private float tiempoDeAtaque;
    private float attackTimer;
    [SerializeField] private AudioClip swordSound;
    static AudioSource audioSource;
    public ParticleSystem dust;
    public void GetKilled()
    {
        isAlive = false;
        attackTimer = 0;
    }
    void Update()
    {
        if (isAlive) 
        {
            //Movimiento del personaje
            
            float xMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.position += new Vector3(xMovement, 0f, 0f);
            bool keyRightDown = Input.GetKeyDown(KeyCode.A);
            bool keyLeftDown = Input.GetKeyDown(KeyCode.D);
            bool TriggerAttack = Input.GetKeyDown(KeyCode.C);
            bool KeyRightUp = Input.GetKeyUp(KeyCode.A);
            bool keyLeftUp = Input.GetKeyUp(KeyCode.D);
            if (keyRightDown && lookFront)
            {
                //Lo rota para que mire hacia la izquierda
               transform.Rotate(0,180,0);
               lookFront = false;
            }
            if (keyLeftDown && !lookFront)
            {
                //Lo rota para que mire hacia adelante
               transform.Rotate(0,180,0);
               lookFront = true;
            }
            if (keyLeftUp || KeyRightUp && !(keyLeftDown || keyRightDown))
            {
                animatorController.SetBool("IsRunning", false);
            }
            if (keyLeftDown || keyRightDown)
            {
                animatorController.SetBool("IsRunning", true);
                CreateDust();

            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
//             CreateDust();
                dust.Play();
            }
            if (TriggerAttack)
            {
                Attack();
            }
            //pregunta si el attackzone esta activado
            if (attackZone.activeInHierarchy)
            {
                //De ser asi se fija hace cuanto esta activado, si supera la variable tiempoDeAtaque lo desactiva
                if (attackTimer >= tiempoDeAtaque)
                {
                    attackZone.SetActive(false);
                    attackTimer = 0;
                }
                else
                {
                    attackTimer += Time.deltaTime;
                }
            }
        }
    }
    void Awake()
    {
        animatorController = GetComponent<Animator>();
        isAlive = true;
        attackZone.SetActive(false);
        attackTimer = 0;
        audioSource = GetComponent<AudioSource>(); 
    }
    private void Attack()
    {
        animatorController.SetTrigger("attackEvent");
        attackZone.SetActive(true); 
        audioSource.PlayOneShot(swordSound);
    }
    void CreateDust(){
        dust.Play();
    }

    private void FixedUpdate()
    {
        bool JumpKey = Input.GetKeyDown(KeyCode.Space);
        
        if (JumpKey)
        { 
        animatorController.SetTrigger("jumpEvent");
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0,7), ForceMode2D.Impulse);
        }
    }
}


