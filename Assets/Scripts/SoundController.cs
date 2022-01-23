using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour {
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioSource soundEffectsAudioSource;

    [SerializeField] AudioClip snakeBiteClip;
    [SerializeField] AudioClip buttonClip;

    [SerializeField] AudioMixer musicAudioMixer;
    [SerializeField] AudioMixer soundEffectsAudioMixer;

    void Start() {
        PlayBackgroundMusic();
    }

    public void ToggleMusicMixer() {
        float value;
        musicAudioMixer.GetFloat("MusicMixerVolume", out value);

        if (value == 0f) {
            musicAudioMixer.SetFloat("MusicMixerVolume", -80f);
        }
        else {
            musicAudioMixer.SetFloat("MusicMixerVolume", 0f);
        }
    }

    public void ToggleSoundEffectsMixer() {
        float value;
        soundEffectsAudioMixer.GetFloat("SoundEffectsMixerVolume", out value);

        if (value == 0f) {
            soundEffectsAudioMixer.SetFloat("SoundEffectsMixerVolume", -80f);
        }
        else {
            soundEffectsAudioMixer.SetFloat("SoundEffectsMixerVolume", 0f);
        }
    }

    public void PlayButtonSound() {
        soundEffectsAudioSource.PlayOneShot(buttonClip);
    }

    public void PlayBiteSound() {
        soundEffectsAudioSource.PlayOneShot(snakeBiteClip);
    }

    void PlayBackgroundMusic() {
        musicAudioSource.Play();
    }
}