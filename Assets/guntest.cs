using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guntest : MonoBehaviour
{
    private void FixedUpdate()
    {
        // 获取鼠标坐标并转换成世界坐标
        Vector3 m_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 因为是2D，用不到z轴。使将z轴的值为0，这样鼠标的坐标就在(x,y)平面上了
        m_mousePosition.z = 0;
        this.transform.LookAt(m_mousePosition);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

    }


}
