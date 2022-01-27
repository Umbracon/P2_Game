using UnityEngine;
using UnityEngine.UI;

public class MenuSpriteToggle : MonoBehaviour {
    [SerializeField] Sprite spriteOn;
    [SerializeField] Sprite spriteOff;

    [SerializeField] bool isOn;

    public void ChangeState() {
        isOn = !isOn;
        GetComponentsInChildren<Image>()[1].sprite = isOn ? spriteOn : spriteOff;
    }
}