using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMovement : MonoBehaviour
{
    public float amplitud = .5f;
    [SerializeField] private Animator animator;
    void Update()
    {
        float newPosX = amplitud * Mathf.Sin(1f * Time.time);
        transform.position += new Vector3(newPosX, 0);
        //llamada de animación por código//
        /*if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetBool("Clicked", true);
        }
        else if (Input.GetKeyUp(KeyCode.P)) 
        {
            animator.SetBool("Clicked", false);
        } */
    }
}
