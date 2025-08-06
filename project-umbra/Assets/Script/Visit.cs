using UnityEngine;
using UnityEngine.SceneManagement;

public class Visit : MonoBehaviour
{
    public TimeManager timeManager;
    public void VisitWorld()
    {
        timeManager.isPaused = true;
        SceneManager.LoadSceneAsync(2);
    }
}
