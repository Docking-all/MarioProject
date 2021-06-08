using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //刚体
    public Rigidbody2D Rigidbody;

    //速度
    public float speed;

    //玩家动画
    public Animator animator;

    //碰撞体
    public Collider2D collider;
    public LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //获取ad水平位移
        float horizontalMove = Input.GetAxis("Horizontal");

        //获取ws垂直位移
        float verticalMove = Input.GetAxis("Vertical");

        //获取面朝方向整数（-1，1）
        float faceDirection = Input.GetAxisRaw("Horizontal");

        if(horizontalMove != 0)
        {
            //玩家刚体的水平速度设置为水平位移×速度，垂直速度保持不变
            Rigidbody.velocity = new Vector2(speed * horizontalMove,Rigidbody.velocity.y);
            //在进行水平移动时将面部朝向的绝对值（）赋值给running，表明正在移动
            animator.SetFloat("Running",Mathf.Abs(faceDirection));
            
        }

        if(verticalMove != 0)
        {
            //玩家刚体的垂直速度设置为垂直位移×速度，水平速度保持不变
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x,speed * verticalMove);
            animator.SetFloat("Running",Mathf.Abs(Input.GetAxisRaw("Vertical")));
            
        }

        if (faceDirection != 0)
        {
            transform.localScale = new Vector2(faceDirection,1);
        }
    }
}
