using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialTrigger : MonoBehaviour
{
    public string nextLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(nextLevel);
    }
}
