using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Image[] healthImages;
    public Text scoreLabel;
    public Text timeLabel;

    private HealthController playerHealth;
    private PlayerController playerScore;
    private Timer timer;
    private int previousHealth;

	public void Awake()
    {
        playerHealth = FindObjectOfType<HealthController>();
        playerScore = FindObjectOfType<PlayerController>();
        timer = FindObjectOfType<Timer>();  
        previousHealth = playerHealth.healthPoints;
	}
	
	public void Update()
    {
        if(playerHealth.healthPoints != previousHealth)
        {
            var health = playerHealth.healthPoints;
            for (int i = 0; i < healthImages.Length; i++)
                healthImages[i].enabled = health-- > 0;

            previousHealth = playerHealth.healthPoints;
        }

        scoreLabel.text = playerScore.score.ToString();
        if (scoreLabel.text.Length < 6)
            scoreLabel.text = new string('0', 6 - scoreLabel.text.Length) + scoreLabel.text;

        var seconds = Mathf.RoundToInt(timer.timeLeft);
        timeLabel.text = (seconds / 60).ToString() + ':' + (seconds % 60 < 10 ? "0" : "") + (seconds % 60);
	}
}
