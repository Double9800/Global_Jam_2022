using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float Speed = 3f;
    public float YOffset = 1f;
    public float XOffste = 1f;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void FixedUpdate()
    {
        Vector3 newPos = new Vector3(Player.position.x + XOffste, Player.position.y + YOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, Speed * Time.fixedDeltaTime);
    }
}
