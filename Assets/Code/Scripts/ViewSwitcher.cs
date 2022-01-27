using JetBrains.Annotations;
using UnityEngine;

public class ViewSwitcher : MonoBehaviour {
    [SerializeField] [CanBeNull] GameObject mainMenuView;
    [SerializeField] [CanBeNull] GameObject optionsView;
    [SerializeField] [CanBeNull] GameObject inGameMenuView;
    [SerializeField] [CanBeNull] GameObject tutorialView;
    [SerializeField] ViewManager viewManager;
    
    public void Quit() => Application.Quit();
    public void ToMainMenu() => StartCoroutine(viewManager.LoadScene("Main Menu"));
    public void MainMenuToOptions() => StartCoroutine(viewManager.LoadView(mainMenuView, optionsView, true));
    public void OptionsToMainMenu() => StartCoroutine(viewManager.LoadView(optionsView, mainMenuView, true));
    public void ToGame() => StartCoroutine(viewManager.LoadScene("Tree Of Life"));
    public void InGameMenuToOptions() => StartCoroutine(viewManager.LoadView(inGameMenuView, optionsView, false));
    public void OptionsToInGameMenu() => StartCoroutine(viewManager.LoadView(optionsView, inGameMenuView, false));
    public void MainMenuToTutorial() => StartCoroutine(viewManager.LoadView(mainMenuView, tutorialView, true));
}