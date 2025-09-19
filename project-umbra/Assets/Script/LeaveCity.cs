using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveCity : MonoBehaviour
{
    
    public void Leave()
    {
        SceneManager.LoadSceneAsync("Dunia2");
    }
}
