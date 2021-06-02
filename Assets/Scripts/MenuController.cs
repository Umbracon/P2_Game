using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    GameObject output;

    TextMeshProUGUI textField;

    bool cooldown = false;

    void Start()
    {
        textField = output.GetComponent<TextMeshProUGUI>();
    }

    public void StartGame()
    {

        SceneManager.LoadSceneAsync("Tree Of Life");
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

        yield return new WaitForSeconds(1.6f);

        textField.text = "";
        cooldown = false;
    }
}
