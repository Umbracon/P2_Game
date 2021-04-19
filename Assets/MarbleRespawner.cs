using UnityEngine;

public class MarbleRespawner : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Deathzone")
            Destroy(gameObject);
    }
}
