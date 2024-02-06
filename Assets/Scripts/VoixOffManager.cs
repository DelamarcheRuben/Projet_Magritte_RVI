using UnityEngine;

public class VoixOffManager : MonoBehaviour
{
    public AudioSource voixOffSource;

    // M�thode pour jouer la voix off
    public void PlayVoixOff()
    {
        if (voixOffSource != null && !voixOffSource.isPlaying)
        {
            voixOffSource.Play();
        }
    }

    // M�thode pour mettre la voix off en pause
    public void PauseVoixOff()
    {
        if (voixOffSource != null && voixOffSource.isPlaying)
        {
            voixOffSource.Pause();
        }
    }

    // M�thode pour arr�ter la voix off
    public void StopVoixOff()
    {
        if (voixOffSource != null)
        {
            voixOffSource.Stop();
        }
    }
}
