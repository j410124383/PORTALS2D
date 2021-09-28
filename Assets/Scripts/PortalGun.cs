using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalGun : FindMG
{
    public GameObject bullet;
    public Transform gun_point;
    public LayerMask shootlayer;

    [SerializeField]private Vector3 m_mousePosition;
    //ǹ�ĳ���
    private void FixedUpdate()
    {


        // ��ȡ������겢ת������������
        m_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
            RaycastHit2D hit = Physics2D.Raycast(gun_point.transform.position,transform.up,shootlayer);

            if (hit.collider)
            {
                 Vector3 hitv3= hit.collider.gameObject.transform.position;
                print(hit.collider.gameObject.name+":"+ hitv3);
                
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(gun_point.transform.position, m_mousePosition);


    }

}
