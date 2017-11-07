using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeLeft { get; private set; }
	
	public void Awake()
    {
        timeLeft = 60.0f;
	}
	
	public void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            SavePersistantData();

            var level = FindObjectOfType<GameplayManager>().level;
            if (level < 3)
                SceneManager.LoadScene("Level " + (level + 1));
            else
                SceneManager.LoadScene("Game Completed");
        }
	}

    private void SavePersistantData()
    {
        var data = FindObjectOfType<PersistantData>();
        data.score = FindObjectOfType<PlayerController>().score;
        data.health = FindObjectOfType<HealthController>().healthPoints;
    }
}
