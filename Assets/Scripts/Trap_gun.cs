using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_gun : MonoBehaviour
{
    public float shoot_rate;
    public Transform gun_point;
    public GameObject bullet;

    private void Awake()
    {
        InvokeRepeating("shoot", 0f, shoot_rate);
    }

    void shoot()
    {
        Instantiate(bullet, gun_point.position,gun_point.rotation);
    }



}
