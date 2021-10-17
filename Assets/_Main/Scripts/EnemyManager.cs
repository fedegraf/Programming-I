using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float maxLife;
    private float currentLife;
    private Animator animatorController;
    private CharacterInput characterinputScript;
    [SerializeField] private GameManager gameManager;
    public string deadAnimation;
    private float timetodie = 2f;
    private float currenttimetodie;
    public UnityEvent EnemyKilled;

    void Start()
    {
        currentLife = maxLife;
    
    }
    private void Awake()
    {
        animatorController = GetComponent<Animator>();
        
    }
    public void GetDamage(float damage)
    {
        if (currentLife > 0)
        {
            currentLife -= damage; 
            
            if (currentLife <= 0)
            {
                Destroy(gameObject);
                EnemyKilled.Invoke();
                //Debug.Log("Se murió el enemy");
                animatorController.SetBool(deadAnimation, true);
                characterinputScript.GetKilled();

                
            }
            else
            {
                animatorController.SetTrigger("GetHitted");
            }   
        }
    }
}