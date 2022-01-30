using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastHitGround : MonoBehaviour
{
    public float distance;
    Rigidbody2D Rb;
    private Animator myAnim;
    private PlayerMovement MyMove;
    public GameObject PosStartTrace;
    public bool Fatta;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        MyMove = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(PosStartTrace.transform.position, -Vector2.up * distance , distance);


        Debug.DrawRay(PosStartTrace.transform.position, -Vector2.up * distance, Color.red);

        if (hit.collider != null)
        {
            Debug.Log("preso");
            Fatta = false;
        }
        else if(hit.collider == null && MyMove.isGrounded == false && MyMove.isJumping == false && Fatta == false)
        {
            
            myAnim.Play("Respawn");
            Fatta = true;
        }

    }
}
