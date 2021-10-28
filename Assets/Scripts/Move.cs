using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    
    private Rigidbody2D rb;     //����
    private Collider2D coll;    //��ײ��
    private Animator Anim;      //����Ч��
   
    [Header("Ħ������")]
    public PhysicsMaterial2D p1;
    public PhysicsMaterial2D p2;

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
        Anim = GetComponent<Animator>();
        rb.sharedMaterial = p1;

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

        if (isGround == true)
        {
            Anim.SetBool("isJump", false);
        }
        else
        {
            Anim.SetBool("isJump", true);
        }
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground); //�ж��Ƿ��ڵ�����

        if (isGround)
        {
            rb.sharedMaterial = p1;
            
        }
        else
        {
            rb.sharedMaterial = p2;
           
        }


        GroundMovement();
        
        Jump();

    }

    void GroundMovement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");      //��ȡ�ƶ�ָ�GetAxisRaw���ص���-1��0��1
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);   //ʵ������ĺ����ƶ�
                                                                            //ʵ������ķ�ת
        if (horizontalMove > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(horizontalMove < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        Anim.SetFloat("Speed", Mathf.Abs(horizontalMove));
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
