using UnityEngine;

public class PhysicsController : MonoBehaviour {
    void Start() {
        DisablePhysics();
    }

    public static void DisablePhysics() {
        Physics.autoSimulation = false;
    }
    public static void EnablePhysics() {
        if (SceneController.anyObstaclePlaced && !Physics.autoSimulation) {
            Physics.autoSimulation = true;
            SceneController.isSimulationRunning = true;
        }
    }
}
