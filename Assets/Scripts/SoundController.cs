using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField, EventRef]
    string menuButton;

    [SerializeField, EventRef]
    string backgroundMusic;

    [SerializeField, EventRef]
    string snakeBite;

    static SoundController controller = null;
    public static SoundController Controller 
    {
        get { return controller; }
    }

    EventInstance instance;

    void Awake()
    {
        instance = RuntimeManager.CreateInstance(backgroundMusic);
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
        RuntimeManager.PlayOneShot(menuButton);
    }

    public void PlayBiteSound() 
    {
        RuntimeManager.PlayOneShot(snakeBite);
    }

    public void PlayBackgroundMusic() 
    {
        instance.start();
    }

    public void StopBackgroundMusic() 
    {
        if (instance.isValid()) 
        {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.release();
            instance.clearHandle();
        }
    }
}
