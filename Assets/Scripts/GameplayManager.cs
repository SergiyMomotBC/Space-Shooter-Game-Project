using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public int level = 1;
    public GameObject pauseMenu;

    private bool isPaused;

    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            if (isPaused)
                Resume();
            else
                Pause();
	}

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
