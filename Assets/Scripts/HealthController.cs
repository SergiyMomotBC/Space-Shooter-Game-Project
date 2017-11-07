using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public int healthPoints { get; private set; }

    private bool wasHurtRecently;
    private float timer;
    private SpriteRenderer sprite;
    private int direction;

    private const float INVINCIBILITY_PERIOD = 2.0f;

    public void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        healthPoints = FindObjectOfType<PersistantData>().health;
    }

    public void Update()
    {
        if (healthPoints == 0)
        {
            FindObjectOfType<PersistantData>().health = 3;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (wasHurtRecently && Time.time - timer >= INVINCIBILITY_PERIOD)
        {
            wasHurtRecently = false;
            direction = 0;
            CancelInvoke();
            sprite.color = Color.white;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (wasHurtRecently)
            return;

        if (other.CompareTag("EnemyLaser"))
        {
            Destroy(other.gameObject);
            LifeLost();
        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<DestroyableEnemy>().Kill();
            LifeLost();
        }
        else if (other.CompareTag("Asteroid"))
            LifeLost();
    }

    private void LifeLost()
    { 
        if (healthPoints > 0)
            healthPoints--;

        wasHurtRecently = true;
        timer = Time.time;

        InvokeRepeating("Flash", 0.0f, 0.1f);
    }

    private void Flash()
    {
        sprite.color = direction++ % 2 == 0 ? Color.black : Color.white;
    }
}