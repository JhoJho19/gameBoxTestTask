using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // target scene index
    [SerializeField] private int sceneIndex; 

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}