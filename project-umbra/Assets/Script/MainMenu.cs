using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator transitionAnimation;
    public void PlayGame()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        transitionAnimation.SetTrigger("Play");
        yield return new WaitForSeconds(2);
        transitionAnimation.SetTrigger("End");
        SceneManager.LoadScene(1);
    }
}
