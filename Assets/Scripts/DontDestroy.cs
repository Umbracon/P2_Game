using UnityEngine;

public class DontDestroy : MonoBehaviour {
    public static DontDestroy objectToSpare;
    void Awake() {
        if (objectToSpare != null && objectToSpare != this) {
            Destroy(gameObject);
            return;
        }

        objectToSpare = this;
        DontDestroyOnLoad(transform.gameObject);
    }
}
