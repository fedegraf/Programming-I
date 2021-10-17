using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinalBossEnemyManager : MonoBehaviour
{
    [SerializeField] public float maxLife;
    [SerializeField] private float currentLife;
    private Animator animatorController;
    private CharacterInput characterinputScript;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private LifeManager lifeManager;
    public string deadAnimation;
    private float timetodie = 2f;
    private float currenttimetodie;
    public Action<float> updateUI;
    public UnityEvent finalBossDefeated;

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
            Debug.Log("current life =" + currentLife);
            updateUI?.Invoke(currentLife);
            Debug.Log("Jajaj Como no vas a poder hacer un invoke?");
            if (currentLife <= 0)
            {
                //Debug.Log("Se murió el enemy");
                animatorController.SetBool(deadAnimation, true);
                characterinputScript.GetKilled();
                finalBossDefeated.Invoke();
            }
            else
            {
                animatorController.SetTrigger("GetHit");
            }
        }
    }
}
