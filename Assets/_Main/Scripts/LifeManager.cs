using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeManager : MonoBehaviour
{
    [SerializeField] private float maxLife;
    private float currentLife;
    private Animator animatorController;
    private CharacterInput characterinputScript;
    public int Enemydead;
    public Action<LifeManager, float> updateUI;
    [SerializeField] public UIManager UIM;
    public new UnityEvent looseEvent;
    void Start()
    {
        currentLife = maxLife;
        Enemydead = 0;
    }
    private void Awake()
    {
        animatorController = GetComponent<Animator>();
        characterinputScript = GetComponent<CharacterInput>();
    }
    public void GetDamage(float damage)
    {
        Debug.Log("GetDamage del Player");
        if (currentLife > 0)
        {
            currentLife -= damage;
            UIM.updateLifeBar(currentLife);
            Debug.Log("currentLife: " + currentLife);
            if (currentLife <= 0)
            {
                Debug.Log("Murio el player");
                animatorController.SetTrigger("Died"); 
                animatorController.SetBool("IsRunning", false);
                characterinputScript.GetKilled();
                looseEvent.Invoke();
            }
            else
            {
                animatorController.SetTrigger("GetHitted");
            }   
        }
    }
}
