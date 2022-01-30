using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    public int ValLife;
    private PlayerHealth MyHealth;
    public string Sound, Sound2;
    public GameObject SpawnPosition;


    private void Start()
    {
        MyHealth = FindObjectOfType<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {          
            AudioManager.instance.Play(Sound);
            AudioManager.instance.Play(Sound2);
            if (MyHealth.lifeCounter >= 9)
            {
                Debug.Log("Ti Attacchi al cazzo");
            }
            else
            {
                MyHealth.lifeCounter += ValLife;
            }
            Debug.Log("Entro");
            other.GetComponent<Respawn>().RespawnPosition = SpawnPosition.transform.position;
            //Animazione Boom
            StartCoroutine(Boom());
        }
    }

    IEnumerator Boom()
    {
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
