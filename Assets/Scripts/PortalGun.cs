using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalGun : FindMG
{
    public GameObject bullet;
    public Transform gun_point;
    public LayerMask shootlayer;
    [Header("传送门物体")]
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
        //当玩家按下x键，角色武器发射
        if (Input.GetButtonDown("Fire1"))
        {
            shoot(0);
        }
        //当玩家按下x键，角色武器发射
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
            print("已检测到");
            Portal[num] = Instantiate(Portal_obj[num], hit.point, Quaternion.identity);
        }

    }

    void ChangeAngle()
    {
        // 获取鼠标坐标并转换成世界坐标
        m_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 因为是2D，用不到z轴。使将z轴的值为0，这样鼠标的坐标就在(x,y)平面上了
        m_mousePosition.z = 0;

        // 武器朝向角度
        float m_weaponAngle = Vector2.Angle(m_mousePosition - this.transform.position, Vector2.up);
        if (transform.position.x < m_mousePosition.x)
        {
            m_weaponAngle = -m_weaponAngle;
        }

        //判断武器正反
        if (m_weaponAngle > 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (m_weaponAngle < 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        // 变换最终角度
        transform.eulerAngles = new Vector3(0, 0, m_weaponAngle);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(gun_point.transform.position, m_mousePosition);


    }

}
