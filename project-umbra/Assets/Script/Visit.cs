using UnityEngine;
using UnityEngine.SceneManagement;

public class Visit : MonoBehaviour
{
    public void VisitWorld()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
