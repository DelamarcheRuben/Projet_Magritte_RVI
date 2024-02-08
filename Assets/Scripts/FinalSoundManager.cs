using System.Runtime.CompilerServices;
using UnityEngine;

public class FinalSoundManager : MonoBehaviour
{
    public AudioSource voixOffSource;
    private bool hasPlayed = false;

    private void Update()
    {
        // Quitter l'application si l'AudioSource a fini de jouer
        if (voixOffSource != null && !voixOffSource.isPlaying && hasPlayed)
        {
            QuitApplication();
        }
    }

    // M�thode pour jouer la voix off
    public void PlayVoixOff()
    {
        if (voixOffSource != null && !voixOffSource.isPlaying)
        {
            hasPlayed = true;
            voixOffSource.Play();
        }
    }

    // M�thode pour quitter l'application
    private void QuitApplication()
    {
        Application.Quit();
    }
}
