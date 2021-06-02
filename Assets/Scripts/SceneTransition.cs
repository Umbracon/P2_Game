using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    public void LoadLevel(bool ignoreAppStart) 
    {
        StartCoroutine(LoadLevel("Tree Of Life", ignoreAppStart)) ;
    }

    IEnumerator LoadLevel(string scene, bool ignoreAppStart) 
    {
        animator.SetTrigger("Proceed");

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(scene);
    }
}
