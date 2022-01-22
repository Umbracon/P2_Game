using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    
    public IEnumerator LoadScene(string scene) {
        animator.SetTrigger("Scene");
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadSceneAsync(scene);
    }
    
    public IEnumerator LoadView([CanBeNull] GameObject from, [CanBeNull] GameObject to) {
        animator.SetTrigger("View");
        yield return new WaitForSeconds(1f);
        if(from != null)
            from.SetActive(false);

        animator.SetTrigger("View");
        if(from != null)
            to.SetActive(true);
    }
}
