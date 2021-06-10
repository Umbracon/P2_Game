using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float yRotationSpeed = 0.6f;
    [SerializeField] float zRotationSpeed = 0.5f;

    CinemachineVirtualCamera virtualCamera;

    float horizontal;
    float vertical;
    float scroll;

    void Start()
    {
        virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        scroll = Input.mouseScrollDelta.y;

        if (Mathf.Abs(horizontal) > 0.1f)
        {
            transform.Rotate(new Vector3(0, -horizontal * yRotationSpeed, 0), Space.World);
        }

        if (Mathf.Abs(vertical) > 0.1f)
        {
            transform.Rotate(new Vector3(0, 0, vertical * zRotationSpeed), Space.Self);
        }

        if (Mathf.Abs(scroll) > 0.1f)
        {
            virtualCamera.m_Lens.FieldOfView -= scroll;
        }
    }
}
