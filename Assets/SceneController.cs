using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public static bool anyObstaclePlaced;
    public static bool isSimulationRunning;

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;

        anyObstaclePlaced = false;
        isSimulationRunning = false;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        PhysicsController.DisablePhysics();
    }

    public void ReloadScene() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
