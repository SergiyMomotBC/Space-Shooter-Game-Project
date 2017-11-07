using UnityEngine;

public class DefaultHighScores : MonoBehaviour
{
    public void Awake()
    {
        if (!PlayerPrefs.HasKey("Place1"))
            LoadDefaultHighScores();
    }

    private void LoadDefaultHighScores()
    {
        PlayerPrefs.SetString("Place1", "Kletenik");
        PlayerPrefs.SetInt("Kletenik", 10000);

        PlayerPrefs.SetString("Place2", "Levitan");
        PlayerPrefs.SetInt("Levitan", 8000);

        PlayerPrefs.SetString("Place3", "Gross");
        PlayerPrefs.SetInt("Gross", 6000);

        PlayerPrefs.SetString("Place4", "Dexter");
        PlayerPrefs.SetInt("Dexter", 4000);

        PlayerPrefs.SetString("Place5", "Jones");
        PlayerPrefs.SetInt("Jones", 2000);
    }
}
