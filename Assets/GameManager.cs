using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Play("CityBackground");
        AudioManager.instance.Play("Jazz");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
