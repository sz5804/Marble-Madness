using UnityEngine;

public class DragMove : MonoBehaviour
{
    [SerializeField] private GameObject localPos;
    [SerializeField] private Vector3 prevMousePos;
    [SerializeField] private bool isDragging;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // reset, no movement based off initial mouse placement
        prevMousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        isDragging = Input.GetMouseButton(0);
        if (isDragging)
        {
            Vector3 move = mousePos - prevMousePos;
            move.Normalize();
            
            gameObject.transform.rotation *= Quaternion.Euler(
                    Mathf.Atan2(move.y, 80) * Mathf.Rad2Deg,
                    Mathf.Atan2(-move.x, 80) * Mathf.Rad2Deg,
                    0);
        }
        else
        {
            localPos.transform.rotation = Quaternion.identity;
        }
            prevMousePos = mousePos;
    }
}
