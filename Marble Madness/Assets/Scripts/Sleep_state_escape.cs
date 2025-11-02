using UnityEngine;

public class Sleep_state_escape : MonoBehaviour
{
    [SerializeField] public Rigidbody marble;
    [SerializeField] public Vector3 startingPosition;
    [SerializeField] public Vector3 currentPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (marble.IsSleeping()) {
            marble.WakeUp();
        }
        currentPosition = transform.position;
    }
}
