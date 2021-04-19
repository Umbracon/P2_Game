using UnityEngine;

public class Quitter : MonoBehaviour {
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            Application.Quit();        
    }
}
