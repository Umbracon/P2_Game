using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
    [SerializeField] Animator animator;
    [SerializeField] GameObject mainMenuView;
    [SerializeField] GameObject optionsView;

    bool cooldown = false;

    public void MainMenuToGame() => StartCoroutine(LoadView("Tree Of Life"));

    public IEnumerator LoadView(string scene) {
        animator.SetTrigger("Scene");
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadSceneAsync(scene);
    }

    public IEnumerator LoadView(GameObject from, GameObject to) {
        animator.SetTrigger("View");
        yield return new WaitForSeconds(1f);
        from.SetActive(false);

        animator.SetTrigger("View");
        yield return new WaitForSeconds(1f);
        to.SetActive(true);
    }

    public void Quit() => Application.Quit();
    public void GameToMainMenu() => StartCoroutine(LoadView("Main Menu"));

    public void MainMenuToOptions() => StartCoroutine(LoadView(mainMenuView, optionsView));

    public void OptionsToMainMenu() => StartCoroutine(LoadView(optionsView, mainMenuView));
}