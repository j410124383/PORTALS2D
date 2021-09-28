using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalGun : FindMG
{
    public GameObject bullet;
    public Transform gun_point;

    //ǹ�ĳ���
    private void FixedUpdate()
    {
        // ��ȡ������겢ת������������
        Vector3 m_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ��Ϊ��2D���ò���z�ᡣʹ��z���ֵΪ0�����������������(x,y)ƽ������
        m_mousePosition.z = 0;

        // ��������Ƕ�
        float m_weaponAngle = Vector2.Angle(m_mousePosition - this.transform.position, Vector2.up);
        if (transform.position.x < m_mousePosition.x)
        {
            m_weaponAngle = -m_weaponAngle;
        }

        //�ж���������
        if (m_weaponAngle > 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (m_weaponAngle < 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        // �任���սǶ�
        transform.eulerAngles = new Vector3(0, 0, m_weaponAngle);

    }


    private void Update()
    {
        //����Ұ���x������ɫ��������
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet_obj=Instantiate(bullet,gun_point.transform.position,gun_point.transform.rotation);
            bullet_obj.transform.localScale = PLAYER.transform.localScale;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

    }

}
