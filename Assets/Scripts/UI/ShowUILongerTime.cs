using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUILongerTime : MonoBehaviour
{

    public GameObject uiObject;
    void Start()
    {
        uiObject.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            Debug.Log("Esta Funzionando");
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(6f);
        Destroy(uiObject);
        Destroy(gameObject);
    }

}
