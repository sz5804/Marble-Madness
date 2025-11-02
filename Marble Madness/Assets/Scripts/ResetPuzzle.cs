using UnityEngine;

public class ResetPuzzle : MonoBehaviour
{
    public Sleep_state_escape ballReference;
    [SerializeField] GameObject puzzle;
    private Vector3 spawnPoint;
    private Vector3 ballState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoint = ballReference.startingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        ballState = ballReference.currentPosition;
        if (ballState.y < -25.0)
        {
            ballReference.marble.transform.position = spawnPoint;
            puzzle.transform.rotation = Quaternion.identity;
            ballReference.marble.linearVelocity = Vector3.zero;
            ballReference.marble.angularVelocity = Vector3.zero;
        }
    }
}
