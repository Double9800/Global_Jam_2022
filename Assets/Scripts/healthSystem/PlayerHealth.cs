using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lifeCounter;
    public GameObject deathPlatrofm;
    private Vector3 deathPosition;
    private Respawn MySpawnPoint;
    public GameObject Poof;
    public GameObject PointPoofSpawn;
    

    // Start is called before the first frame update
    void Start()
    {
        MySpawnPoint = GetComponent<Respawn>();
        lifeCounter = 9;
    }

    // Update is called once per frame
    void Update()
    {
        deathPosition = gameObject.transform.position;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Death();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Damage")
        {
            Death();
        }
    }
    public void Death()
    {
        if (lifeCounter > 0)
        {
            Instantiate(deathPlatrofm, deathPosition, Quaternion.identity);
            lifeCounter -= 1;
            Debug.Log(lifeCounter);
            MySpawnPoint.RespawnAction();
        }
        else
        {
            Debug.Log("Non hai più vite");
        //qui si schiatta in maniera definitiva
        }
        Instantiate(Poof, deathPosition, Quaternion.identity);
        AudioManager.instance.Play("CatDeath");
    }
}
