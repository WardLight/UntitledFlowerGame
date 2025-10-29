using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    public void StartSceneTransition()
    {
        SceneManager.LoadScene("victoruGrabScene");
    }
}
