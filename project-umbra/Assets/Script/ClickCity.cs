using UnityEngine;
using UnityEngine.EventSystems;

public class ClickCity : MonoBehaviour
{
    public MytherraManager WorldManager;
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        Debug.Log("clicked!");
        WorldManager.VisitCity(gameObject.name);
    }
}
