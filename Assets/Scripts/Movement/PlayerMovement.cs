using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float movementInput;
    private float jumpTimeMax;
    public float jumpTime;
    private bool isJumping;
    private bool isGrounded;
    public LayerMask isMask;
    public Transform feet;
    public float radius;
    public float jumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movementInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movementInput * speed, rb.velocity.y);
        Debug.Log(rb.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feet.position, radius, isMask);

        if (movementInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (movementInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

       //Vector2 moveDirection = rb.velocity;
       //
       //if (moveDirection != Vector2.zero)
       //{
       //    float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
       //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
       //}

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeMax = jumpTime;
            rb.velocity = Vector2.up * jumpSpeed;
        }
        if (Input.GetKey(KeyCode.Space)&& isJumping == true)
        {
            if (jumpTimeMax > 0)
            {
                rb.velocity = Vector2.up * jumpSpeed;
                jumpTimeMax -= Time.deltaTime;
            }
        }
        else
        {
            isJumping = false;
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
