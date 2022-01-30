using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : MonoBehaviour
{
    public void Walk1()
    {
        AudioManager.instance.Play("Walk1");
    }
    public void Walk2()
    {
        AudioManager.instance.Play("Walk2");
    }
    public void Walk3()
    {
        AudioManager.instance.Play("Walk3");
    }
    public void Walk4()
    {
        AudioManager.instance.Play("Walk4");
    }
}
