using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 50f, maxspeed = 10, jumpPow = 520f;
    public Rigidbody2D r2;
    public bool grounded = true, left = true;
    public Animator animator;
    public bool canDoubleJump = false;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Grounded", grounded);
        animator.SetFloat("Speed", Mathf.Abs(r2.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded) // đang ở dưới đất
            {
                grounded = false;
                canDoubleJump = true; // set trạng thái có thể nhảy doubleJump
                r2.AddForce(Vector2.up * jumpPow);
            }
            else // đang nhảy trên không
            {
                if (canDoubleJump) // có thể nhảy double
                {
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow);
                    canDoubleJump = false;
                }
            }

        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);
        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

        if (h>0 && left)
        {
            Flip();
        }
        if (h < 0 && !left)
        {
            Flip();
        }
    }

    private void Flip()
    {
        left = !left;
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
