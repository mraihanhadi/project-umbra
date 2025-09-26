using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraTarget;
    public float panSpeed = 5f;
    public float dragSpeed = 3f;
    private Vector3 dragOrigin;

    [Header("Zoom Settings")]
    public CinemachineVirtualCamera virtualCam;
    public float zoomSpeed = 2f;
    public float minZoom = 3f;
    public float maxZoom = 15f;
    public bool isUIOpen = false;

    void Update()
    {
        if (isUIOpen) return;
        HandlePan();
        HandleDrag();
        HandleZoom();
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

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            float currentSize = virtualCam.m_Lens.OrthographicSize;
            float newSize = Mathf.Clamp(currentSize - scroll * zoomSpeed, minZoom, maxZoom);
            virtualCam.m_Lens.OrthographicSize = newSize;
        }
    }

    public void SetUIOpen(bool state)
    {
        isUIOpen = state;
    }
}
