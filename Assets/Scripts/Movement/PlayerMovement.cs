using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float movementInput;
    private float jumpTimeMax;
    public float jumpTime,distance;
    public bool isJumping,Fatta;
    public bool isGrounded;
    public LayerMask isMask;
    public Transform feet;
    public float radius;
    public float jumpSpeed;
    private bool isCrouch;
    public Vector2 ColliderSizeCrouch ,ColliderPosCrouch,ColliderSizeInitial,ColliderPosInitioal;
    private BoxCollider2D myBox;
    private SpriteRenderer Mysprite;
    private Animator Myanim;
    public GameObject PosStartTrace;


    // Start is called before the first frame update
    void Start()
    {
        isCrouch = false;
        rb = GetComponent<Rigidbody2D>();
        myBox = GetComponent<BoxCollider2D>();
        Mysprite = GetComponent<SpriteRenderer>();
        Myanim = GetComponent<Animator>();
       
    }

    private void FixedUpdate()
    {
        if (isCrouch == false)
        {
            movementInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(movementInput * speed, rb.velocity.y);
        }
        RaycastHit2D hit = Physics2D.Raycast(PosStartTrace.transform.position, -Vector2.up * distance, distance);
        if (hit.collider != null)
        {
            isGrounded = true;
            Debug.Log("preso");
            Fatta = false;

        }
        else { isGrounded = false; }

        Debug.DrawRay(PosStartTrace.transform.position, -Vector2.up * distance, Color.red);
        if (hit.collider != null && Fatta == true)
        {
            isGrounded = true;
            AudioManager.instance.Play("JumpEnd");
            
        }
        else if (hit.collider == null && isGrounded == false && isJumping == false && Fatta == false)
        {

            Myanim.Play("Respawn");
            Fatta = true;
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

        //isGrounded = Physics2D.OverlapCircle(feet.position, radius, isMask);

        if (movementInput > 0)
        {
            //Mysprite.flipX = false;
            //Myanim.Play("Movement");
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (movementInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            //Mysprite.flipX = true;
            //Myanim.Play("Movement");
        }

        if (Input.GetKey(KeyCode.D) )
        {
            Myanim.SetBool("Move", true);
            //AudioManager.instance.Play("Walk");
        }
        if (Input.GetKey(KeyCode.A) )
        {
            Myanim.SetBool("Move", true);
            //AudioManager.instance.Play("Walk");
        }
        if (Input.GetKeyUp(KeyCode.D) )
        {
            Myanim.SetBool("Move", false);
        }
        if (Input.GetKeyUp(KeyCode.A) )
        {
            Myanim.SetBool("Move", false);
        }


        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            Myanim.Play("Jump");
            AudioManager.instance.Play("JumpStart");
            isJumping = true;
            jumpTimeMax = jumpTime;
            rb.velocity = Vector2.up * jumpSpeed;
            AudioManager.instance.Play("JumpStart");
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
