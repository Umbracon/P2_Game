using UnityEngine;

public class Leaves : MonoBehaviour {
    [SerializeField] MaterialManager materialManager;
    Snake snake;
    MeshRenderer meshRenderer;

    public SnakeRenderer snakeRenderer;

    void Start() {
        snakeRenderer = GetComponentInChildren<SnakeRenderer>();
        snake = FindObjectOfType<Snake>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnMouseOver() {
        if (!snake.isCoolingDown)
            materialManager.ChangeLeavesMaterial(meshRenderer, MaterialManager.LeavesMaterial.Hovered);
    }

    void OnMouseExit() {
        if (!snake.isCoolingDown)
            materialManager.ChangeLeavesMaterial(meshRenderer, MaterialManager.LeavesMaterial.Default);
    }

    void OnMouseDown() {
        if (snake.leafWithCurrentlyUncoiledSnake != null) {
            snake.CoilCurrentSnakeIfAny();
            snake.leafWithCurrentlyUncoiledSnake = null;
        }
        else if (
            !snake.isCoolingDown && !snake.isSnakeUncoiled) {
            UncoilSnake();
        }
    }

    void UncoilSnake() {
        snake.leafWithCurrentlyUncoiledSnake = this;
        snake.StartCoolDownCoroutine();
        StartCoroutine(snakeRenderer.UncoilSnake(1f / 60f));
    }
}