using UnityEngine;

public class ClickCity : MonoBehaviour
{
    public MytherraManager WorldManager;
    void OnMouseDown()
    {
        Debug.Log("clicked!");
        WorldManager.VisitCity(gameObject.name);
    }
}
