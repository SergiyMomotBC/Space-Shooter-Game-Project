using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    [Header("Sounds")]
    public AudioSource shootSound;

    [Header("Laser")]
    public GameObject laser;

    [Header("Movement sprites")]
    public Sprite idle;
    public Sprite left;
    public Sprite right;

    public int score { get; private set; }

    private SpriteRenderer spriteRenderer;
    private Vector2 xBounds;

	public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        var halfCameraWidth = Camera.main.orthographicSize * Camera.main.aspect;
        xBounds = new Vector2(
            -halfCameraWidth + spriteRenderer.bounds.extents.x,
            halfCameraWidth - spriteRenderer.bounds.extents.x
        );
	}

    public void Start()
    {
        score = FindObjectOfType<PersistantData>().score;
    }

    public void OnEnemyKilled(int points)
    {
        score += points;
    }

	public void Update()
    {
        if (Time.timeScale == 0.0f)
            return;

        HorizontalMovement();

        if (Input.GetButtonDown("Fire"))
            Shoot();
	}

    private void HorizontalMovement()
    {
        var hSpeed = Input.GetAxisRaw("Horizontal");

        transform.Translate(hSpeed * speed * Time.deltaTime, 0.0f, 0.0f);

        if (hSpeed < 0.0f)
            spriteRenderer.sprite = left;
        else if (hSpeed > 0.0f)
            spriteRenderer.sprite = right;
        else
            spriteRenderer.sprite = idle;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, xBounds.x, xBounds.y),
            transform.position.y,
            transform.position.z);
    }

    private void Shoot()
    {
        var spawnPosition = new Vector2(
            transform.position.x, 
            transform.position.y + spriteRenderer.bounds.size.y
        );

        Instantiate(laser, spawnPosition, Quaternion.identity);

        shootSound.Play();
    }
}