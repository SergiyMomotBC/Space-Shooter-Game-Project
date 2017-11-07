using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Sprite[] enemySkins;

    public GameObject laser;
    public Vector2 velocity;
    public float amplitude = 2.5f;

    new private SpriteRenderer renderer;
    new private Collider2D collider;

    private float xOrigin;
    private float speedModifier;

    private float shootInterval;

    public void Awake()
    {    
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = enemySkins[Random.Range(0, enemySkins.Length - 1)];

        collider = gameObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;

        speedModifier = 1.0f;

        xOrigin = transform.position.x;

        shootInterval = Random.Range(1.0f, 2.0f);

        InvokeRepeating("Shoot", 1.0f, shootInterval);
    }

    public void Update()
    {
        if (Time.timeScale == 0.0f)
            return;

        transform.Translate(
            speedModifier * velocity.x * Time.deltaTime, 
            speedModifier * velocity.y * Time.deltaTime, 
            0.0f
        );

        var distance = transform.position.x - xOrigin;
        if (Mathf.Abs(distance) >= amplitude)
            if (distance < 0.0f && velocity.x < 0.0f)
                velocity.x *= -1;
            else if (distance > 0.0f && velocity.x > 0.0f)
                velocity.x *= -1;
    }

    private void Shoot()
    {
        if (laser != null && renderer.isVisible)
            Instantiate(laser, transform.position, Quaternion.identity);
    }
}
