using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : MonoBehaviour
{
    public void Walk()
    {
        AudioManager.instance.Play("Walk");
    }

}
