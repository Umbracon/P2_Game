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
        if(!snake.isCoolingDown) 
            materialManager.ChangeLeavesMaterial(meshRenderer, MaterialManager.LeavesMaterial.Hovered);
    }

    void OnMouseExit() {
        if(!snake.isCoolingDown)
            materialManager.ChangeLeavesMaterial(meshRenderer, MaterialManager.LeavesMaterial.Default);
    }

    void OnMouseDown() {
        snake.CoilCurrentSnakeIfAny();

        if (!snake.isCoolingDown)
            UncoilSnake();
    }

    void UncoilSnake() {
        StartCoroutine(snakeRenderer.UncoilSnake(1f / 60f));
        snake.leafWithCurrentlyUncoiledSnake = this;
        snake.StartCoolDownCoroutine();
    }
}