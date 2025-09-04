using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingScreen : MonoBehaviour
{
     [Header("Scroll Settings")]
    public RawImage scrollingImage;
    public float scrollSpeed = 0.2f;
    public float scrollDuration = 5f; // Time before switching scenes

    [Header("Loading Bar (Optional)")]
    public Slider loadingBar;

    [Header("Scene Settings")]
    public string nextSceneName = "Main_view";

    private float elapsedTime = 0f;
    private Vector2 uvOffset = Vector2.zero;

    void Start()
    {
        if (loadingBar != null)
            loadingBar.value = 0f;
    }
    void Update()
    {
        
        // Scroll image (Y axis down)
        uvOffset.y -= scrollSpeed * Time.deltaTime;
        scrollingImage.uvRect = new Rect(uvOffset, scrollingImage.uvRect.size);

        // Track time
        elapsedTime += Time.deltaTime;

        // Update loading bar
        if (loadingBar != null)
            loadingBar.value = Mathf.Clamp01(elapsedTime / scrollDuration);

        // When done, load next scene
        if (elapsedTime >= scrollDuration)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.timeManager.ResumeTime();
            }
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
