using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreUpdater : MonoBehaviour
{
    public InputField input;
    public Text scoreLabel;

    public void Awake()
    {
        scoreLabel.text = FindObjectOfType<PersistantData>().score.ToString();
    }

    public void UpdateScore()
    {
        var name = input.text;
        var score = FindObjectOfType<PersistantData>().score;

        for(int i = 1; i <= 5; i++)
            if (score > PlayerPrefs.GetInt(PlayerPrefs.GetString("Place" + i)))
            {
                PlayerPrefs.DeleteKey(PlayerPrefs.GetString("Place" + i));
                PlayerPrefs.SetString("Place" + i, name);
                PlayerPrefs.SetInt(name, score);
                break;
            }

        Destroy(FindObjectOfType<PersistantData>().gameObject);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Main Menu");
    }
}
