using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour {
    [HideInInspector] public Leaves leafWithCurrentlyUncoiledSnake;
    public bool isCoolingDown = false;
    public bool isLevelCompleted = false;

    void Update() {
        if (isLevelCompleted && Input.anyKeyDown) {
            FindObjectOfType<MenuController>().GameToMainMenu();
        }
    }

    public void ReloadScene() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartCoolDownCoroutine() {
        StartCoroutine("CoolDownCoroutine");
    }

    IEnumerator CoolDownCoroutine() {
        var cooldown = 2.0f;
        isCoolingDown = true;
        yield return new WaitForSeconds(cooldown);
        isCoolingDown = false;
    }

    public void CoilCurrentSnakeIfAny() {
        if (leafWithCurrentlyUncoiledSnake != null)
            StartCoroutine(leafWithCurrentlyUncoiledSnake.snakeRenderer.CoilSnake(1f / 60f));
    }
}