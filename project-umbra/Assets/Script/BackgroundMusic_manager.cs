using UnityEngine;
public class BackgroundMusic_manager : MonoBehaviour
{
    public static BackgroundMusic_manager instance;
   
   private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
