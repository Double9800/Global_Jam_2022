﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag ("Player"))
        {
            Debug.Log("Entro");
            other.GetComponent<Respawn>().RespawnPosition = GetComponent<Transform>().position;
        }
    }
}
