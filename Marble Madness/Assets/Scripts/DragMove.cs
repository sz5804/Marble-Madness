using UnityEngine;

public class DragMove : MonoBehaviour
{
    [SerializeField] private GameObject localPos;
    [SerializeField] private Vector3 prevMousePos;
    [SerializeField] private bool isDragging;
    [SerializeField] public bool cameraToggle;
    [SerializeField] public float cameraSpeed;
    [SerializeField] public float moveSpeed;

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
        Vector3 move = mousePos - prevMousePos - gameObject.transform.forward;
        
        // rotate object
        if (isDragging && !cameraToggle)
        {
            move.Normalize();
            // left-right
            if (gameObject.transform.position.x > -45 && gameObject.transform.position.x < 45)
            {
                gameObject.transform.rotation *= Quaternion.Euler(
                    0,
                    Mathf.Atan2(-move.x, 100) * Mathf.Rad2Deg * moveSpeed,
                    0);
            }
            else if (gameObject.transform.position.x >= -135 && gameObject.transform.position.x <= 135)
            {
                gameObject.transform.rotation *= Quaternion.Euler(
                   0,
                   0,
                   Mathf.Atan2(-move.x, 100) * Mathf.Rad2Deg * moveSpeed);
            }
            else
            {
                gameObject.transform.rotation *= Quaternion.Euler(
                    0,
                    Mathf.Atan2(move.x, 100) * Mathf.Rad2Deg * moveSpeed,
                    0);
            }

            // up-down
            if (gameObject.transform.position.y > -45 && gameObject.transform.position.y < 45)
            {
                gameObject.transform.rotation *= Quaternion.Euler(
                    Mathf.Atan2(move.y, 100) * Mathf.Rad2Deg * moveSpeed,
                    0,
                    0);
            }
            else if (gameObject.transform.position.y >= -135 && gameObject.transform.position.y <= 135)
            {
                gameObject.transform.rotation *= Quaternion.Euler(
                    0,
                    0,
                    -Mathf.Atan2(move.y, 100) * Mathf.Rad2Deg * moveSpeed);
            }
            else
            {
                gameObject.transform.rotation *= Quaternion.Euler(
                    -Mathf.Atan2(move.y, 100) * Mathf.Rad2Deg * moveSpeed,
                    0,
                    0);
            }

            //gameObject.transform.rotation *= Quaternion.Euler(
            //        Mathf.Atan2(move.y, 100) * Mathf.Rad2Deg * 2,
            //        Mathf.Atan2(-move.x, 100) * Mathf.Rad2Deg,
            //        Mathf.Atan2(move.z, 100) * Mathf.Rad2Deg);
            localPos.transform.rotation *= gameObject.transform.rotation;
            gameObject.transform.rotation = Quaternion.identity;
        }
        // camera mode
        else if (isDragging && cameraToggle) {
            Camera.main.transform.position += -move * Time.deltaTime * cameraSpeed;
        }
        prevMousePos = mousePos;
    }
}
