using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float yRotationSpeed = 0.6f;
    [SerializeField] float zRotationSpeed = 2f;

    float horizontal;
    float vertical;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0.1f)
        {
            transform.Rotate(new Vector3(0, -horizontal * yRotationSpeed, 0), Space.World);
        }

        if (Mathf.Abs(vertical) > 0.1f)
        {
            transform.Rotate(new Vector3(0, 0, vertical + zRotationSpeed), Space.Self);
        }
    }
}
