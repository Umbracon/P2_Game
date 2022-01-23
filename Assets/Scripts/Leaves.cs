using UnityEngine;

public class Leaves : MonoBehaviour {
    [SerializeField] MaterialManager materialManager;
    Snake snake;
    MeshRenderer meshRenderer;

    bool wasPreviouslyCoiled;

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
        Debug.Log($"początek: {snake.isSnakeUncoiled}");
        snake.leafWithCurrentlyUncoiledSnake = this;
        if (snake.leafWithPreviouslyUncoiledSnake != null && snake.leafWithCurrentlyUncoiledSnake == snake.leafWithPreviouslyUncoiledSnake) {
            if (snake.isSnakeUncoiled) {
                snake.CoilCurrentSnakeIfAny();
               
                Debug.Log("zwijam");
            }
        }

        if (!snake.isCoolingDown && !wasPreviouslyCoiled) {
            UncoilSnake();
            Debug.Log("rozwijam");
        }

        wasPreviouslyCoiled = !wasPreviouslyCoiled;

        snake.leafWithPreviouslyUncoiledSnake = this;
        Debug.Log($"koniec: {snake.isSnakeUncoiled}");
    }

    void UncoilSnake() {
        snake.StartCoolDownCoroutine();
        StartCoroutine(snakeRenderer.UncoilSnake(1f / 60f));
    }
}