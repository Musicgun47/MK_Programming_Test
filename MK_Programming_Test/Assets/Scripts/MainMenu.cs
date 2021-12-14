using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Stroop_Test");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
