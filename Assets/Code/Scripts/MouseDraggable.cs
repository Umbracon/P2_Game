using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MouseDraggable : MonoBehaviour {
    Vector3 screenPoint;
    Vector3 offset;
    Vector3 snakeRoot;
    Vector3 destPoint;

    bool dragging;

    Rigidbody rigid;

    void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    void Start() {
        snakeRoot = transform.parent.position;
    }

    void OnMouseDown() {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        dragging = true;
    }

    void OnMouseUp() {
        dragging = false;
    }

    void FixedUpdate() {
        if (dragging) {
            var point = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            destPoint = Camera.main.ScreenToWorldPoint(point) + offset;

            rigid.AddForce((destPoint - rigid.position) * 50f);
            rigid.velocity *= 0.8f;

            if (Vector3.Distance(destPoint, snakeRoot) > 4.0f) {
                dragging = false;
            }
        }
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawSphere(snakeRoot, 0.06f);

    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(destPoint, 0.06f);
    //}
}