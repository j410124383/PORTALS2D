using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;

    private void Awake()
    {
        Invoke("Die", 5f);

    }

    private void Update()
    {
        this.gameObject.transform.Translate(Vector2.right /speed*transform.localScale.x);
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag!="Player")
        {
            Die();
        }
       
   
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

}
