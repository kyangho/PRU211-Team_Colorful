using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource audioSource;

    public void PlayAudioOneShot(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
