using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
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
        
        if (snake.isSnakeUncoiled) {
            snake.CoilCurrentSnakeIfAny();
            snake.isSnakeUncoiled = false;
            snake.snakeBehaviourQueue.Enqueue("I was coiled!");
        }
        else {
            UncoilSnake();
            snake.snakeBehaviourQueue.Enqueue("I was uncoiled, because no other snake is uncoiled!");
        }
        
        snake.currentlyClickedLeaves = this;
        
        if(snake.currentlyClickedLeaves != snake.previouslyClickedLeaves && snake.previouslyClickedLeaves != null) {
            UncoilSnake();
            snake.snakeBehaviourQueue.Enqueue("I was uncoiled, because it was not from these leaves I was summoned!");
        }

        snake.previouslyClickedLeaves = snake.currentlyClickedLeaves;
    }

    void UncoilSnake() {
        snake.StartCoolDownCoroutine();
        StartCoroutine(snakeRenderer.UncoilSnake(1f / 60f));
    }
}