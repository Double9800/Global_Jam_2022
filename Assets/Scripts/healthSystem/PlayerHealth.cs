using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lifeCounter;
    public GameObject deathPlatrofm;
    private Vector3 deathPosition;
    private RespawnBase myRespawn;

    // Start is called before the first frame update
    void Start()
    {
        myRespawn = FindObjectOfType<RespawnBase>();
        lifeCounter = 9;
    }

    // Update is called once per frame
    void Update()
    {
        deathPosition = gameObject.transform.position;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Death();
            myRespawn.RespawnAction();
        }
    }
    public void Death()
    {
        if (lifeCounter > 0)
        {
            Instantiate(deathPlatrofm, deathPosition, Quaternion.identity);
            lifeCounter -= 1;
            Debug.Log(lifeCounter);
        }
        else
        {
            Debug.Log("Non hai più vite");
        //qui si schiatta in maniera definitiva
        }
    }
}
