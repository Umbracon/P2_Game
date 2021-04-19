using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] float speed = 0.6f;

    private float y;

    private void Update() {
        y = Input.GetAxis("Horizontal");

        if (Mathf.Abs(y) > 0.1)
            transform.Rotate(0, -y * speed, 0);
    }
}
