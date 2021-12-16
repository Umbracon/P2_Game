using UnityEngine;

public class LevelQualifier : MonoBehaviour {
    [SerializeField] float minVelocityMagnitude;
    [SerializeField] GameObject panel;

    Rigidbody rb;
    Snake snake;

    void Start()
    {
        snake = FindObjectOfType<Snake>();
    }

    private void OnTriggerEnter(Collider other)
    {
            rb = other.GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other) 
    {
        if (rb.velocity.magnitude <= minVelocityMagnitude && 
            !snake.isLevelCompleted && 
            other.CompareTag("Player")) 
        {           
            panel.SetActive(true);
            snake.isLevelCompleted = true;
        }
    }
}

