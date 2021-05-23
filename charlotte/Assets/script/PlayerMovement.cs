using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    bool isGrounded;
    [SerializeField]
     Transform groundCheck;
     [SerializeField]
    Transform groundCheckL;
    [SerializeField]
    Transform groundCheckR;
    [SerializeField]
    float RunSpeed=1.5f;
    [SerializeField]
    float JumpSpeed = 3f;
 [SerializeField]

    void Start()
    {
        animator =GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))||
            Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))||
            Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
         
        }
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(RunSpeed, rb2d.velocity.y);
          
            if(isGrounded)
            animator.Play("Run");
             
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-RunSpeed, rb2d.velocity.y);
            if (isGrounded)
          animator.Play("Run");

            spriteRenderer.flipX = true;
        }
        else
        {       if(isGrounded)
              animator.Play("idle");
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if (Input.GetKey("space")&& isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, JumpSpeed);
            animator.Play("jump");
        }
        if(Input.GetMouseButtonDown(0)){
            animator.Play("Attack");
        }
    }
}

