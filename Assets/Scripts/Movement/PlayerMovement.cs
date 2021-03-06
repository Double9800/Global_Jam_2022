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
    private bool isCrouch;
    public Vector2 ColliderSizeCrouch ,ColliderPosCrouch,ColliderSizeInitial,ColliderPosInitioal;
    private BoxCollider2D myBox;
    private SpriteRenderer Mysprite;
    

    // Start is called before the first frame update
    void Start()
    {
        isCrouch = false;
        rb = GetComponent<Rigidbody2D>();
        myBox = GetComponent<BoxCollider2D>();
        Mysprite = GetComponent<SpriteRenderer>();
       
    }

    private void FixedUpdate()
    {


        if (isCrouch == false)
        {
            movementInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(movementInput * speed, rb.velocity.y);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.C) && isGrounded)
        {
            Debug.Log("Mi accovaccio");
            isCrouch = true;
            myBox.size = ColliderSizeCrouch;
            myBox.offset = ColliderPosCrouch;
        }
        if (Input.GetKeyUp(KeyCode.C) && isGrounded)
        {
            Debug.Log("MiAlzo");
            isCrouch = false;
            myBox.size = ColliderSizeInitial;
            myBox.offset = ColliderPosInitioal;
        }
        isGrounded = Physics2D.OverlapCircle(feet.position, radius, isMask);

        if (movementInput > 0)
        {
            Mysprite.flipX = false;

        } else if (movementInput < 0)
        {
            Mysprite.flipX = true;
            
        }

        


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
