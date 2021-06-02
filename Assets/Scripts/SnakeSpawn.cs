using UnityEngine;

public class SnakeSpawn : MonoBehaviour
{
    [SerializeField]
    Material hoverMaterial;

    Material defaultMaterial;
    SceneController sceneController;
    RopeController snakeSpawnModule;

    bool isSnakeUncoiled = false;

    void Start()
    {
        snakeSpawnModule = GetComponentInChildren<RopeController>();
        sceneController = FindObjectOfType<SceneController>();
        defaultMaterial = GetComponent<MeshRenderer>().material;
    }

    void OnMouseOver()
    {
        GetComponent<MeshRenderer>().material = hoverMaterial;
    }

    void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    void OnMouseDown()
    {
        if (isSnakeUncoiled)
        {
            StartCoroutine(snakeSpawnModule.CoilSnake(1f / 60f));
            isSnakeUncoiled = false;

        } else
        {
            SnakeSpawn uncoiledSnake = sceneController.uncoiledSnake;
            if (uncoiledSnake != null)
            {
                StartCoroutine(uncoiledSnake.snakeSpawnModule.CoilSnake(1f / 60f));
                uncoiledSnake.isSnakeUncoiled = false;
            }

            StartCoroutine(snakeSpawnModule.UncoilSnake(1f / 60f));
            isSnakeUncoiled = true;
            sceneController.uncoiledSnake = this;
        }
    }
}
