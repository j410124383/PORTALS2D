using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shoot : FindMG
{

    public GameObject bullet;
    public Transform gun_point;

    private void Update()
    {
        //����Ұ���x������ɫ��������
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject bullet_obj=Instantiate(bullet,gun_point.transform.position,gun_point.transform.rotation);
            bullet_obj.transform.localScale = PLAYER.transform.localScale;
        }

    }


}
