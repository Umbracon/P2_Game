using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour {
    [SerializeField] MaterialManager materialManager;
    [HideInInspector] public Leaves currentlyClickedLeaves;
    [HideInInspector] public Leaves previouslyClickedLeaves;
    public bool isCoolingDown;
    public bool isLevelCompleted;
    public bool isSnakeUncoiled;
    public bool isAppleBitten;

    SnakeHead snakeHead;
    
    public Queue<string> snakeBehaviourQueue;

    void Start() {
        snakeBehaviourQueue = new Queue<string>();
    }

    void Update() {
        if (isLevelCompleted && Input.anyKeyDown) {
            FindObjectOfType<ViewSwitcher>().ToMainMenu();
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
            snakeHead = currentlyClickedLeaves.GetComponentInChildren<SnakeHead>();
            var joints = snakeHead.GetComponentsInChildren<FixedJoint>();
            joints[1].connectedBody = null;
        }
        StartCoroutine(currentlyClickedLeaves.snakeRenderer.CoilSnake(1f / 60f));
    }

    void ChangeAllLeavesMaterial(MaterialManager.LeavesMaterial leavesMaterial) {
        foreach (var leaves in FindObjectsOfType<Leaves>()) {
            materialManager.ChangeLeavesMaterial(leaves.GetComponent<MeshRenderer>(), leavesMaterial);
        }
    }
}