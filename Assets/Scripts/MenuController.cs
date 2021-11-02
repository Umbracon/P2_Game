using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    GameObject output;

    [SerializeField]
    Animator animator;

    [SerializeField]
    GameObject startGameButton;

    TextMeshProUGUI textField;

    Button button;

    bool cooldown = false;


    void Awake()
    {
        button = startGameButton.GetComponent<Button>();
    }

    void Start()
    {
        textField = output.GetComponent<TextMeshProUGUI>();
    }
    
    public void StartGame() 
    {
        StartCoroutine(LoadLevel("Tree Of Life"));
    }

    IEnumerator LoadLevel(string name)
    {
        animator.SetTrigger("Proceed");

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadSceneAsync(name);
    }

    public void ShowPoliteError(int errorIndex)
    {
        if (!cooldown)
        {
            switch (errorIndex)
            {
                case 1:
                    StartCoroutine(SpellString("* sorry, I haven't been implemented yet :( *"));
                    cooldown = true;
                    break;
                case 2:
                    StartCoroutine(SpellString("* ummm, neither have I :((( *"));
                    cooldown = true;
                    break;
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator SpellString(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            textField.text += text[i];

            yield return new WaitForSeconds(0.04f);
        }

        yield return new WaitForSeconds(0.8f);

        textField.text = "";
        cooldown = false;
    }

    public void ReturnToMenu() 
    {
        StartCoroutine(LoadLevel("Main Menu"));
    }
}
