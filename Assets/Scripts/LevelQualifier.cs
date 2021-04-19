using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelQualifier : MonoBehaviour {
    [SerializeField] float minVelocityMagnitude;
    [SerializeField] GameObject panel;

    Rigidbody rb;

    static bool isCompleted = false;
     
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            rb = other.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerStay(Collider other) {
        if (rb.velocity.magnitude <= minVelocityMagnitude && !isCompleted) {
            ObstacleRotator.isRotatingEnabled = false;
            panel.SetActive(true);
            isCompleted = true;
        }
        
    }
}

