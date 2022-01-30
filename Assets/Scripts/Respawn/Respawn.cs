using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Rigidbody2D MyRb;
    public Vector3 RespawnPosition;
    public GameObject Poof;
    public GameObject PositionPoof;
    private Animator MyAnim;
    
    private void Awake()
    {
        MyRb = GetComponent<Rigidbody2D>();
        MyAnim = GetComponent<Animator>();      
    }
    public void RespawnAction()
    {

        MyRb.velocity = Vector3.zero;
        GetComponent<Transform>().position = RespawnPosition;
        Instantiate(Poof, PositionPoof.transform.position, Quaternion.identity);
        MyAnim.Play("Respawn");
    }
}
