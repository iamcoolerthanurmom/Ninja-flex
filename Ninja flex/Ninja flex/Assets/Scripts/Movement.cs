using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jump;
    public Animator animator;

    private float move;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsEnemy;
    private int extrajumps;
    public int extrajumpsValue;

    public float dashDistance = 15f;
    bool isDashing;
    float doubleTapTime;
    KeyCode lastKeyCode;



    void Start()
    {
        extrajumps = extrajumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround | whatIsEnemy);



        move = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Walk", Mathf.Abs(move));

        if (!isDashing)
        {
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
        }
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        if (facingRight == false && move > 0)
        {
            Flip();
        }
        else if (facingRight == true && move < 0)
        {
            Flip();
        }
    }

    void Update()
    {
      
        
        if (isGrounded == true)
        {
            extrajumps = extrajumpsValue;
        }

        if (Input.GetButtonDown("Jump") && extrajumps > 0)
        {
            rb.velocity = Vector2.up * jump;
            extrajumps--;
        }
        else if (Input.GetButtonDown("Jump") && extrajumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jump;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
            {
                StartCoroutine(Dash(-1f));
                animator.SetTrigger("Dash");
            }
            else
            {
                doubleTapTime = Time.time + 0.2f;
            }

            lastKeyCode = KeyCode.A;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
            {
                StartCoroutine(Dash(1f));
                animator.SetTrigger("Dash");
            }
            else
            {
                doubleTapTime = Time.time + 0.2f;
            }

            lastKeyCode = KeyCode.D;
        }




        
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    IEnumerator Dash(float direction)
    {
        
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float garvity = rb.gravityScale;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.2f);
        isDashing = false;
        rb.gravityScale = garvity;
    }


    /*
    public float moveSpeed = 500f;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movemment = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movemment * Time.deltaTime * moveSpeed;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {


            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }
    */
}
