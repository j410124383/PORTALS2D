using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guntest : MonoBehaviour
{
    private void FixedUpdate()
    {
        // ��ȡ������겢ת������������
        Vector3 m_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ��Ϊ��2D���ò���z�ᡣʹ��z���ֵΪ0�����������������(x,y)ƽ������
        m_mousePosition.z = 0;
        this.transform.LookAt(m_mousePosition);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

    }


}
