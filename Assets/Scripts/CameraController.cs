using System;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour {
    [SerializeField] float yRotationSpeed = 60f;
    [SerializeField] float zRotationSpeed = 50f;
    [SerializeField] float zRotationLimit = 70f;
    [SerializeField] float zoomInLimit = 25f;
    [SerializeField] float zoomOutLimit = 110f;
    [SerializeField] float cameraDamping = 5f;
    CinemachineVirtualCamera virtualCamera;
    float yRotation;
    float zRotation;
    float scroll;
    float cameraDistance;
    
    void Start() {
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        cameraDistance = virtualCamera.m_Lens.FieldOfView;
    }

    void Update() {
        CalculateYRotation();
        CalculateZRotation();
        RotateCamera();
        CalculateZoomDistance();
        Zoom();
    }

    void CalculateYRotation() {
        yRotation += -Input.GetAxis("Horizontal") * yRotationSpeed * Time.deltaTime;
    }

    void CalculateZRotation() {
        zRotation += Input.GetAxis("Vertical") * zRotationSpeed * Time.deltaTime;
        zRotation = Mathf.Clamp(zRotation, zRotationLimit * -1, zRotationLimit);
    }

    void RotateCamera() {
        transform.rotation = Quaternion.Euler(0, yRotation, zRotation);
    }

    void CalculateZoomDistance() {
        cameraDistance -= Input.mouseScrollDelta.y;
        cameraDistance = Mathf.Clamp(cameraDistance, zoomInLimit, zoomOutLimit);
    }
    void Zoom() {
        virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(virtualCamera.m_Lens.FieldOfView, cameraDistance, cameraDamping * Time.deltaTime);
    }
}