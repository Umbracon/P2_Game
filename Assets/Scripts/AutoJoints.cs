using UnityEngine;

public class AutoJoints : MonoBehaviour
{
    void Awake() 
    {
        GetComponent<CharacterJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
    }
}
