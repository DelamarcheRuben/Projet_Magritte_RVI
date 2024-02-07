using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjSoundManager : MonoBehaviour
{
    public Console console;
    public void playSound(AudioSource audio)
    {
	console.AddLine("\nVous avez parlé au guide")
        audio.Play();
    }
}
