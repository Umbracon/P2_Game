using UnityEngine;

public class LevelQualifier : MonoBehaviour {
    [SerializeField] float minVelocityMagnitude;
    [SerializeField] GameObject panel;

    Rigidbody rb;
    Snake snake;

    void Start() {
        snake = FindObjectOfType<Snake>();
    }

    void OnTriggerEnter(Collider other) {
        rb = other.GetComponent<Rigidbody>();
    }

    void OnTriggerStay(Collider other) {
        if (rb.velocity.magnitude <= minVelocityMagnitude &&
            !snake.isLevelCompleted &&
            other.CompareTag("Attachable")) {
            panel.SetActive(true);
            snake.isLevelCompleted = true;
        }
    }
}