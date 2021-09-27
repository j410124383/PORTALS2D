using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMG : MonoBehaviour
{

    protected GameObject PLAYER;
    protected PlayerState PS;

    private void Awake()
    {
        PLAYER = GameObject.FindWithTag("Player");
        PS = PLAYER.GetComponent<PlayerState>();

    }

}
