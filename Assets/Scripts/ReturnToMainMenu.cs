using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            ToMainMenu();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
