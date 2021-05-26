using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 0.6f;
    [SerializeField] float translationSpeed = 0.01f;

    private float x;
    private float y;

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (Mathf.Abs(x) > 0.1f)
        {
            transform.Rotate(0, -x * rotationSpeed, 0);
        }

        if (Mathf.Abs(y) > 0.1f)
        {
            transform.Rotate(0, 0, -y * translationSpeed);
        }
    }
}
