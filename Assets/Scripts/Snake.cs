using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour {
    [SerializeField] MaterialManager materialManager;
    [HideInInspector] public Leaves leafWithCurrentlyUncoiledSnake;
    public bool isCoolingDown;
    public bool isLevelCompleted;
    public bool isSnakeUncoiled;
    public bool isAppleBitten;

    SnakeHead snakeHead;

    void Update() {
        if (isLevelCompleted && Input.anyKeyDown) {
            FindObjectOfType<ViewSwitcher>().GameToMainMenu();
        }
    }

    public void ReloadScene() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartCoolDownCoroutine() {
        StartCoroutine(nameof(CoolDownCoroutine));
    }

    IEnumerator CoolDownCoroutine() {
        var cooldown = 2.0f;
        isCoolingDown = true;
        ChangeAllLeavesMaterial(MaterialManager.LeavesMaterial.Cooldown);
        yield return new WaitForSeconds(cooldown);
        isCoolingDown = false;
        ChangeAllLeavesMaterial(MaterialManager.LeavesMaterial.Default);
    }

    public void CoilCurrentSnakeIfAny() {
        if (isAppleBitten) {
            snakeHead = leafWithCurrentlyUncoiledSnake.GetComponentInChildren<SnakeHead>();
            var joints = snakeHead.GetComponentsInChildren<FixedJoint>();
            joints[1].connectedBody = null;
        }
        StartCoroutine(leafWithCurrentlyUncoiledSnake.snakeRenderer.CoilSnake(1f / 60f));
    }

    void ChangeAllLeavesMaterial(MaterialManager.LeavesMaterial leavesMaterial) {
        foreach (var leaves in FindObjectsOfType<Leaves>()) {
            materialManager.ChangeLeavesMaterial(leaves.GetComponent<MeshRenderer>(), leavesMaterial);
        }
    }
}