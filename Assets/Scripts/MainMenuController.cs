using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void HighScoresButtonPressed()
    {
        SceneManager.LoadScene("High Scores");
    }

    public void HowToPlayButtonPressed()
    {
        SceneManager.LoadScene("How To Play");
    }

    public void SettingsButtonPressed()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }
}
