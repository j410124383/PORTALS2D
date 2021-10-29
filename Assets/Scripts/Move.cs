using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    
    private Rigidbody2D rb;     //刚体
    private Collider2D coll;    //碰撞体
    private Animator Anim;      //动画效果
   
    [Header("摩擦材质")]
    public PhysicsMaterial2D p1;
    public PhysicsMaterial2D p2;

    public float speed, jumpForce;  //移动速度和跳跃力量
    public Transform groundCheck;   //地面监测点的位置
    public LayerMask ground;        //图层layer

    public bool isGround;   //两个是否在地面的状态
    [SerializeField] bool isjumppress;
 

    void Start()
    {
        //以后补充Awake方法内
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        Anim = GetComponent<Animator>();
        rb.sharedMaterial = p1;

    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") )  //判断是否按下跳跃键和可跳跃的次数
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
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground); //判断是否在地面上

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
        float horizontalMove = Input.GetAxisRaw("Horizontal");      //获取移动指令，GetAxisRaw返回的是-1、0、1
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);   //实现人物的横向移动
                                                                            //实现人物的翻转
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

        if (isGround&& isjumppress==true)  //按下了跳跃键且在地面
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isjumppress = false;
            
        }						

    }


}
