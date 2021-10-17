using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationFromPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private SpriteRenderer sprite;
    private void Update()
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.identity;
        }
        else if (player.transform.position.x < transform.position.x)
        {
            //transform.Rotate(0, 180, 0);
            sprite.flipX = true;
        }
        else
        {
            //transform.rotation = Quaternion.identity;
            sprite.flipX = false;
        }
    }
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
}
