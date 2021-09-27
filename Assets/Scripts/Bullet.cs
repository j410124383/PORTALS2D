using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : FindMG
{
    //private Rigidbody2D rb;     //����
    //private Collider2D coll;    //��ײ��

    public LayerMask layer;        //ͼ��layer
    public float speed;
    public float power;

    private void Awake()
    {
        Invoke("Die", 5f);

    }

    private void Update()
    {
        this.gameObject.transform.Translate(Vector2.right /speed*transform.localScale.x);

        Collider2D col = Physics2D.OverlapCircle(transform.position, 0.1f, layer);
        if (col)
        {
            if (col.gameObject.GetComponent<PlayerState>())
            {
                col.gameObject.GetComponent<PlayerState>().changeHP(-power);
            }
            
            Die();
        }

    }


    void Die()
    {
        Destroy(this.gameObject);
    }

}
