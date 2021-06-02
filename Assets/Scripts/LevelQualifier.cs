using UnityEngine;

public class LevelQualifier : MonoBehaviour {
    [SerializeField] float minVelocityMagnitude;
    [SerializeField] GameObject panel;

    Rigidbody rb;
    SceneController sceneController;

    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
    }

    private void OnTriggerEnter(Collider other)
    {
            rb = other.GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other) 
    {
        if (rb.velocity.magnitude <= minVelocityMagnitude && 
            !sceneController.isLevelCompleted && 
            other.CompareTag("Player")) 
        {           
            panel.SetActive(true);
            sceneController.isLevelCompleted = true;
        }
    }
}

