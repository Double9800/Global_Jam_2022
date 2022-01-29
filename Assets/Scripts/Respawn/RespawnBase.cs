using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBase : MonoBehaviour

{
    public Transform player;
    public Transform RespawnPoint;
    public Rigidbody2D RigidB;

    public void RespawnAction()
    {
        player.transform.position = RespawnPoint.transform.position;
        RigidB.velocity = Vector2.zero;
    }
}

