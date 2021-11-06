

using UnityEngine;

public class SoundController : MonoBehaviour
{

    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioSource soundEffectsAudioSource;

    [SerializeField] AudioClip snakeBiteClip;
    [SerializeField] AudioClip buttonClip;
    
    static SoundController controller = null;
    public static SoundController Controller 
    {
        get { return controller; }
    }

    void Start()
    {
        if (controller != null && controller != this)
        {
            Destroy(gameObject);
            return;
        } else
        {
            controller = this;
        }
        DontDestroyOnLoad(transform.gameObject);
        PlayBackgroundMusic();
    }

    public void PlayButtonSound()
    {
        soundEffectsAudioSource.PlayOneShot(buttonClip);
    }

    public void PlayBiteSound() 
    {
        soundEffectsAudioSource.PlayOneShot(snakeBiteClip);
    }

    public void PlayBackgroundMusic()
    {
        musicAudioSource.Play();
    }
}