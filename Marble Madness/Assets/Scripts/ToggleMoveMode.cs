using UnityEngine;
using UnityEngine.UI;

public class ToggleMoveMode : MonoBehaviour
{
    [SerializeField] DragMove dragMove;
    [SerializeField] Toggle toggle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraMode()
    {
        dragMove.cameraToggle = toggle.isOn;
    }
}
