using JetBrains.Annotations;
using UnityEngine;

public class ViewSwitcher : MonoBehaviour {
    [SerializeField] [CanBeNull] GameObject mainMenuView;
    [SerializeField] [CanBeNull] GameObject optionsView;
    [SerializeField] [CanBeNull] GameObject inGameMenuView;
    [SerializeField] ViewManager viewManager;
    
    public void Quit() => Application.Quit();
    public void GameToMainMenu() => StartCoroutine(viewManager.LoadScene("Main Menu"));
    public void MainMenuToOptions() => StartCoroutine(viewManager.LoadView(mainMenuView, optionsView));
    public void OptionsToMainMenu() => StartCoroutine(viewManager.LoadView(optionsView, mainMenuView));
    public void MainMenuToGame() => StartCoroutine(viewManager.LoadScene("Tree Of Life"));
    public void InGameMenuToOptions() => StartCoroutine(viewManager.LoadView(inGameMenuView, optionsView));
    public void OptionsToInGameMenu() => StartCoroutine(viewManager.LoadView(optionsView, inGameMenuView));
}