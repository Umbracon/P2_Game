using UnityEngine;
using UnityEngine.UI;

public class SoundControllerRefLoader : MonoBehaviour {
    [SerializeField] SoundController soundController;
    [SerializeField] Button button;
    [SerializeField] bool isMusicButton;
    void Awake() {
        var sparedObject = DontDestroy.objectToSpare;
        soundController = sparedObject.GetComponent<SoundController>();
    }

    void Start() {
        if(isMusicButton)
            button.onClick.AddListener(delegate { soundController.ToggleMusicMixer();});
        else 
            button.onClick.AddListener(delegate { soundController.ToggleSoundEffectsMixer();});
    }
}
