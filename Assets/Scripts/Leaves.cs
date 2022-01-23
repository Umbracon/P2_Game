using UnityEngine;

public class Leaves : MonoBehaviour {
    [SerializeField] MaterialManager materialManager;
    Snake snake;
    MeshRenderer meshRenderer;

    public SnakeRenderer snakeRenderer;
    bool skipUncoiling;

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
        if (snake.leafWithPreviouslyUncoiledSnake != null && snake.isSnakeUncoiled) {
            snake.CoilCurrentSnakeIfAny();
            Debug.Log("zwijam");
            if(snake.leafWithCurrentlyUncoiledSnake != snake.leafWithPreviouslyUncoiledSnake)
                skipUncoiling = true;
        }

        if (!snake.isSnakeUncoiled || snake.leafWithCurrentlyUncoiledSnake != snake.leafWithPreviouslyUncoiledSnake) {
            if (!snake.isCoolingDown && !skipUncoiling) {
                UncoilSnake();
                Debug.Log("rozwijam");
            }
        }

        snake.leafWithPreviouslyUncoiledSnake = snake.leafWithCurrentlyUncoiledSnake;
        skipUncoiling = false;

    }

    void UncoilSnake() {
        snake.leafWithCurrentlyUncoiledSnake = this;
        snake.StartCoolDownCoroutine();
        StartCoroutine(snakeRenderer.UncoilSnake(1f / 60f));
    }
}