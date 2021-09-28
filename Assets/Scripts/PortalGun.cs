using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalGun : FindMG
{
    public GameObject bullet;
    public Transform gun_point;

    //枪的朝向
    private void FixedUpdate()
    {
        // 获取鼠标坐标并转换成世界坐标
        Vector3 m_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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


    private void Update()
    {
        //当玩家按下x键，角色武器发射
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
