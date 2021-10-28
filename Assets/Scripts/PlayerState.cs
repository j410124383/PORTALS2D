using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : FindMG
{
    [Header("��ɫ״̬")]
    public float HP;
    public float MaxHP;
    public bool isDie;
    private Animator Anim;

    private void Awake()
    {
        MaxHP = 100F;
        HP = MaxHP;
        isDie = true;
        Anim = GetComponent<Animator>();
    }

    public void changeHP(float hp)
    {
        HP += hp;

    }

    private void Update()
    {
        if (HP<=0)
        {
            HP = 0;
        isDie = false;
        Anim.SetBool("isDie",true);
        }
    }
    void ToDie()
    {
        HP = 0;
        isDie = false;
        Anim.SetBool("isDie",true);
    }

}
