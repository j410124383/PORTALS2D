using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : FindMG
{
    [Header("��ɫ״̬")]
    public float HP;
    public float MaxHP;

    private void Awake()
    {
        MaxHP = 100F;
        HP = MaxHP;

    }

    public void changeHP(float hp)
    {
        HP += hp;

    }


}
