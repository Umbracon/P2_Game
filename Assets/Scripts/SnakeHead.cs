using System;
using UnityEngine;

public class SnakeHead : MonoBehaviour {
    FixedJoint joint;
    Rigidbody targetRb;
    Snake snake;
    SoundController soundController;

    void Awake() {
        var sparedObject = DontDestroy.objectToSpare;
        soundController = sparedObject.GetComponent<SoundController>();

        snake = FindObjectOfType<Snake>();

        var rb = gameObject.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;

        snake.isAppleBitten = false;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("Attachable") && !snake.isAppleBitten) {
            var activeHead = gameObject.GetComponentInChildren<SnakeHead>();

            FixedJoint[] joints = activeHead.GetComponentsInChildren<FixedJoint>();
            joint = joints[1];
            joint.connectedBody = collision.transform.GetComponent<Rigidbody>();

            targetRb = collision.gameObject.GetComponent<Rigidbody>();
            targetRb.isKinematic = false;

            snake.isAppleBitten = true;

            soundController.PlayBiteSound();
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(1) && snake.isAppleBitten) {
            DetachApple();
        }
    }

    public void DetachApple() {
        joint.connectedBody = null;
        snake.isAppleBitten = false;
    }
}