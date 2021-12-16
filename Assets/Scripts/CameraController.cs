using System;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour {
    [SerializeField] float yRotationSpeed = 60f;
    [SerializeField] float zRotationSpeed = 50f;
    [SerializeField] float zRotationLimit = 70f;
    CinemachineVirtualCamera virtualCamera;
    float yRotation;
    float zRotation;
    float scroll;

    void Start() {
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    void Update() {
        yRotation += -Input.GetAxis("Horizontal") * yRotationSpeed * Time.deltaTime ;
        zRotation += Input.GetAxis("Vertical") * zRotationSpeed * Time.deltaTime ;
        scroll = Input.mouseScrollDelta.y;
        
        transform.rotation = Quaternion.Euler(0, yRotation, Mathf.Clamp(zRotation, zRotationLimit * -1, zRotationLimit) );
        
        Debug.Log(Time.deltaTime);
    }
    /*void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        scroll = Input.mouseScrollDelta.y;
        if (Mathf.Abs(horizontal) > 0.1f)
            transform.Rotate(new Vector3(0, -horizontal * yRotationSpeed, 0), Space.World);
        if (Mathf.Abs(vertical) > 0.1f) {
            transform.Rotate(new Vector3(0, 0, vertical * zRotationSpeed), Space.Self);
            transform.eulerAngles.z 
        }

        if (Mathf.Abs(scroll) > 0.1f)
            virtualCamera.m_Lens.FieldOfView -= scroll;
    }
    */

    static float GetNegativeRotationValues(float angle) {
        return (angle > 180) ? angle - 360 : angle;
    }
}