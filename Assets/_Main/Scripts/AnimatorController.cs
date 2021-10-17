using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterInput player = GetComponent<CharacterInput>();
        
        if (player !=null)
        {
            animator.SetTrigger("Open");
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Open");
        }
    }
}
