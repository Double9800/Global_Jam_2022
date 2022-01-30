using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int lifeCounter;
    public GameObject deathPlatrofm;
    private Vector3 deathPosition;
    private Respawn MySpawnPoint;
    public GameObject Poof;
    public GameObject PointPoofSpawn;
    public Text LifeTXT;
    public GameObject SpawnPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        MySpawnPoint = GetComponent<Respawn>();
        lifeCounter = 9;
        //LifeTXT.text = lifeCounter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        LifeTXT.text = lifeCounter.ToString();

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
        if (lifeCounter >= 1)
        {
            Instantiate(deathPlatrofm, deathPosition, Quaternion.identity);
            lifeCounter -= 1;
            Debug.Log(lifeCounter);
            MySpawnPoint.RespawnAction();
        }
        if(lifeCounter == 0)
        {
           SceneManager.LoadScene(0);
           transform.position = SpawnPoint.transform.position;
           lifeCounter = 9;
        }
        Instantiate(Poof, deathPosition, Quaternion.identity);
        AudioManager.instance.Play("CatDeath");
    }
}
