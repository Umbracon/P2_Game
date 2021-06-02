using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [HideInInspector]
    public SnakeSpawn uncoiledSnake = null;

    public bool isLevelCompleted = false;

    void Update()
    {
        if (isLevelCompleted && Input.anyKeyDown) 
        {
            SceneManager.LoadSceneAsync("Main Menu");
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
