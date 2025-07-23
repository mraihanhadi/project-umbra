using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraTarget;
    public float panSpeed = 5f;
    public float dragSpeed = 3f;
    private Vector3 dragOrigin;

    void Update()
    {
        HandlePan();
        HandleDrag();
    }

    void HandlePan()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontalMovement, verticalMovement, 0);
        cameraTarget.position += move * panSpeed * Time.deltaTime;
    }

    void HandleDrag()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            dragOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Camera.main.ScreenToWorldPoint(dragOrigin);
            cameraTarget.position -= new Vector3(delta.x, delta.y, 0);
            dragOrigin = Input.mousePosition;
        }
    }
    
}
