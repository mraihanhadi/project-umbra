using UnityEngine;
using TMPro;

public class DebugLogPanel : MonoBehaviour
{
    public TextMeshProUGUI logText;  // assign in Inspector
    private string logHistory = "";

    public GameObject debugPanel;
    public void TogglePanel()
    {
        debugPanel.SetActive(!debugPanel.activeSelf);
    }
    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        // Add timestamp for clarity
        logHistory += $"[{System.DateTime.Now:HH:mm:ss}] {logString}\n";
        logText.text = logHistory;
    }
}
