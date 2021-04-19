using UnityEngine;

public class ObstacleRotator : MonoBehaviour {

    Vector3 mousePreviousPosition = Vector3.zero;
    Vector3 mouseDeltaPosition = Vector3.zero;

    public static bool isRotatingEnabled = true;

    void OnMouseDrag() {
        if(isRotatingEnabled) { 
            mouseDeltaPosition = Input.mousePosition - mousePreviousPosition;
            if (Vector3.Dot(transform.up, Vector3.up) >= 0)
                transform.Rotate(transform.up, Vector3.Dot(mouseDeltaPosition, Camera.main.transform.right), Space.World);
            else
                transform.Rotate(transform.up, -Vector3.Dot(mouseDeltaPosition, Camera.main.transform.right), Space.World);
            transform.Rotate(transform.right, -Vector3.Dot(mouseDeltaPosition, Camera.main.transform.up), Space.World);
        }

        mousePreviousPosition = Input.mousePosition;
    }
}
