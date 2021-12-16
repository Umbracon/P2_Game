using UnityEngine;

public class Leaf : MonoBehaviour {
    [SerializeField] Material hoverMaterial;
    Material defaultMaterial;
    Snake snake;
    public SnakeRenderer snakeRenderer;


    void Start() {
        snakeRenderer = GetComponentInChildren<SnakeRenderer>();
        snake = FindObjectOfType<Snake>();
        defaultMaterial = GetComponent<MeshRenderer>().material;
    }

    void OnMouseOver() {
        GetComponent<MeshRenderer>().material = hoverMaterial;
    }

    void OnMouseExit() {
        GetComponent<MeshRenderer>().material = defaultMaterial;
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