using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<LifeManager>().UIM.winUI.SetActive(true);
            collision.gameObject.GetComponent<LifeManager>().UIM.uI.SetActive(false);
    }
}
