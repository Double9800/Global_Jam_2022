using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    public int ValLife;
    private PlayerHealth MyHealth;
    public string Sound;


    private void Start()
    {
        MyHealth = FindObjectOfType<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {
            //AudioManager.instance.Play(Sound);
            if(MyHealth.lifeCounter >= 9)
            {
                Debug.Log("Ti Attacchi al cazzo");
            }
            else
            {
                MyHealth.lifeCounter += ValLife;
            }
            Debug.Log("Entro");
            other.GetComponent<Respawn>().RespawnPosition = GetComponent<Transform>().position;
            Destroy(gameObject);
        }
    }
}
