using UnityEngine;

public class ObstacleActivator : MonoBehaviour {
    [SerializeField] GameObject[] target;

    private void OnMouseDown() {
        if (SceneController.isSimulationRunning == false) {
            for (int i = 0; i < target.Length; i++) {
                target[i].SetActive(true);
            }
            gameObject.SetActive(false);

            if (!SceneController.anyObstaclePlaced)
                SceneController.anyObstaclePlaced = true;
        }
    }
}
