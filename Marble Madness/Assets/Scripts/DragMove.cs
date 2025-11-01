using UnityEngine;

public class DragMove : MonoBehaviour
{
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
            
            //gameObject.transform.rotation *= Quaternion.Euler(
            //        move.y,
            //        -move.x,
            //        0);
            gameObject.transform.rotation *= Quaternion.Euler(
                    Mathf.Atan2(move.y, 20) * Mathf.Rad2Deg,
                    -move.x,
                    0);
        }
        prevMousePos = mousePos;
    }
}
