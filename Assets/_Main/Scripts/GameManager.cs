using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private GameObject palanca;
    [SerializeField] private int AmountOfEnemies;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            EnemyManager myEnemyManager = new EnemyManager();
            myEnemyManager.EnemyKilled.AddListener(EnemyGotKilled);            
        }

    }

    private void EnemyGotKilled()
    {
        AmountOfEnemies--;
        if (AmountOfEnemies == 3)
        {
            palanca.SetActive(true);
        }
        else
        {
            palanca.SetActive(false);
        }

    }

    public void SearchEnemy(GameObject enemy)
    {
        for (int contador = 0; contador < enemies.Count; contador++)
        {
            if (enemies[contador].gameObject.name == enemy.name) DeleteEnemy(contador);
        }
    }

    private void DeleteEnemy(int index)
    {
        enemies.RemoveAt(index);
    }

    public int GetEnemiesAmount()
    {
        return enemies.Count;
    }

}
