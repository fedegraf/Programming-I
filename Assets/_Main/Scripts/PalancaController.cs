using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaController : MonoBehaviour
{
    [SerializeField] private GameObject escalera;

    public void ActivaEscalera()
    {
        escalera.SetActive(true);
    }

}
