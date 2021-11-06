using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    FixedJoint joint;
    Rigidbody targetRb;

    bool bitten;

    void Awake()
    {
        var rb = gameObject.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        bitten = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.CompareTag("Attachable") || collision.transform.CompareTag("Player")) && !bitten)
        { 
            FixedJoint[] joints = gameObject.GetComponentsInChildren<FixedJoint>();
            joint = joints[1];
            joint.connectedBody = collision.transform.GetComponent<Rigidbody>();

            targetRb = collision.gameObject.GetComponent<Rigidbody>();
            targetRb.isKinematic = false;

            bitten = true;
            
        FindObjectOfType<SoundController>().PlayBiteSound();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && bitten) 
        {
            joint.connectedBody = null;

            bitten = false;
        }
    }
}
