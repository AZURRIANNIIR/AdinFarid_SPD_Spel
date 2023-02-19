using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public float wallSlideSpeed = 3f;
    public GameObject slime;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private bool isGrounded = false;
    //private bool isTouchingWall = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontal * speed, rb.velocity.y);
        rb.velocity = move;

        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        //else if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    Destroy(collision.gameObject);
        //}
    }

    public bool isFalling()
    {
        if (rb.velocity.y < -1f)
        {
            return true;
        }
        return false;
    }



    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //  if (collision.gameObject.CompareTag("Wall"))
    //{
    //  isTouchingWall = false;
    //    }
    //}
}

