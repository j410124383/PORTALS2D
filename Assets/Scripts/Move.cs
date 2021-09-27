using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    private Rigidbody2D rb;     //����
    private Collider2D coll;    //��ײ��
    private Animator anim;      //����Ч��

    public float speed, jumpForce;  //�ƶ��ٶȺ���Ծ����
    public Transform groundCheck;   //��������λ��
    public LayerMask ground;        //ͼ��layer

    public bool isGround;   //�����Ƿ��ڵ����״̬
    [SerializeField] bool isjumppress;
 

    void Start()
    {
        //�Ժ󲹳�Awake������
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") )  //�ж��Ƿ�����Ծ���Ϳ���Ծ�Ĵ���
        {
            if (isGround)
            {
                isjumppress = true;
            }
            
        }
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground); //�ж��Ƿ��ڵ�����

        GroundMovement();

        Jump();

    }

    void GroundMovement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");      //��ȡ�ƶ�ָ�GetAxisRaw���ص���-1��0��1
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);   //ʵ������ĺ����ƶ�
                                                                            //ʵ������ķ�ת
        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }
    }
  

    void Jump()
    {

        if (isGround&& isjumppress==true)  //��������Ծ�����ڵ���
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isjumppress = false;
        }						

    }


}