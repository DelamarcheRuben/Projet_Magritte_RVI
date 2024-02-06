using UnityEngine;

public class VoixOffManager : MonoBehaviour
{
    public AudioSource voixOffSource;

    // Méthode pour jouer la voix off
    public void PlayVoixOff()
    {
        if (voixOffSource != null && !voixOffSource.isPlaying)
        {
            voixOffSource.Play();
        }
    }

    // Méthode pour mettre la voix off en pause
    public void PauseVoixOff()
    {
        if (voixOffSource != null && voixOffSource.isPlaying)
        {
            voixOffSource.Pause();
        }
    }

    // Méthode pour arrêter la voix off
    public void StopVoixOff()
    {
        if (voixOffSource != null)
        {
            voixOffSource.Stop();
        }
    }
}
