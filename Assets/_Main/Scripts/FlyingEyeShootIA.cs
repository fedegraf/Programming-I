using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FlyingEyeShootIA : MonoBehaviour
{
    public GameObject bullet;
    private float timeBetweenShoots;
    public float startTime;
    [SerializeField] private Transform player;

    [SerializeField] private Transform firepoint;
    [SerializeField] private float distance;
    public void Start()
    {
        timeBetweenShoots = startTime;
    }
    private void FixedUpdate()
    {
        float currentdistance = Mathf.Abs(player.transform.position.x - transform.position.x);
        if (timeBetweenShoots <= 0 && currentdistance <= distance)
        {
/*            int layerMask = 1 << 8;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward,1, layerMask);
            if (hit.rigidbody != null)
            {
*/                Instantiate(bullet, firepoint.position, Quaternion.identity); 
                sourceManager.PlaySound("ShootFlyEye");
                timeBetweenShoots = startTime;   
            }
//        }
        else
        {
            timeBetweenShoots -= Time.deltaTime;
        }
    }
        
    }