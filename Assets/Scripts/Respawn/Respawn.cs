using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Rigidbody2D MyRb;
    public Vector3 RespawnPosition;
    public GameObject Poof;
    public GameObject PositionPoof;
    
    private void Awake()
    {
        MyRb = GetComponent<Rigidbody2D>();
        
    }
    public void RespawnAction()
    {

        MyRb.velocity = Vector3.zero;
        GetComponent<Transform>().position = RespawnPosition;
        Instantiate(Poof, PositionPoof.transform.position, Quaternion.identity);
    }
}
