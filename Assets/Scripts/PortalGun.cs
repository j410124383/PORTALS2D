using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalGun : FindMG
{
    public GameObject bullet;
    public Transform gun_point;
    public LayerMask shootlayer;
    [Header("����������")]
    public GameObject[] Portal;
    [SerializeField]private GameObject[] Portal_obj;

    [SerializeField]private Vector3 m_mousePosition;

    private void Awake()
    {
        Portal = new GameObject[2];
        Portal_obj = new GameObject[2];
        Portal_obj[0]=Resources.Load("Prefab/Portal_01")as GameObject;
        Portal_obj[1] = Resources.Load("Prefab/Portal_02") as GameObject;
    }


    private void FixedUpdate()
    {
        ChangeAngle();


    }

    private void Update()
    {
        //����Ұ���x������ɫ��������
        if (Input.GetButtonDown("Fire1"))
        {
            shoot(0);
        }
        //����Ұ���x������ɫ��������
        if (Input.GetButtonDown("Fire2"))
        {
            shoot(1);
        }


    }

    void shoot(int num)
    {
        if (Portal[num])
        {
            Destroy(Portal[num].gameObject);
        }
        RaycastHit2D hit = Physics2D.Raycast(gun_point.transform.position, transform.up, shootlayer);
        if (hit.collider)
        {
            print("�Ѽ�⵽");
            Portal[num] = Instantiate(Portal_obj[num], hit.point, Quaternion.identity);
        }

    }

    void ChangeAngle()
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(gun_point.transform.position, m_mousePosition);


    }

}
