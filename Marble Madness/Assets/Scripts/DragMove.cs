using UnityEngine;

public class DragMove : MonoBehaviour
{
    [SerializeField] private GameObject localPos;
    [SerializeField] private Vector3 prevMousePos;
    [SerializeField] private bool isDragging;
    [SerializeField] public bool cameraToggle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // reset, no movement based off initial mouse placement
        prevMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        // current mouse position
        Vector3 mousePos = Input.mousePosition;
        // detect if mouse is dragging
        isDragging = Input.GetMouseButton(0);

        // mouse drag vector 
        Vector3 move = mousePos - prevMousePos;
        
        // rotate object
        if (isDragging && !cameraToggle)
        {
            move.Normalize();
            gameObject.transform.rotation *= Quaternion.Euler(
                    Mathf.Atan2(move.y, 100) * Mathf.Rad2Deg,
                    Mathf.Atan2(-move.x, 100) * Mathf.Rad2Deg,
                    0);
        }
        // camera mode
        else if (isDragging && cameraToggle) {
            Camera.main.transform.position += -move * Time.deltaTime;
        }
        else
        {
            localPos.transform.rotation *= gameObject.transform.rotation;
            gameObject.transform.rotation = Quaternion.identity;
        }
        prevMousePos = mousePos;
    }
}
