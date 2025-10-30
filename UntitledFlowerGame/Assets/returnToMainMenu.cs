using UnityEngine;
using UnityEngine.SceneManagement;

public class returnToMainMenu : MonoBehaviour
{
    public void StartSceneTransition()
    {
        SceneManager.LoadScene("MainMenu");
    }
}