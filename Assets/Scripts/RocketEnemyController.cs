using UnityEngine;

public class RocketEnemyController : MonoBehaviour
{
    public float speed = 1.0f;
    public float shootInterval = 2.0f;
    public GameObject missle;

    public void Awake()
    {
        InvokeRepeating("ShootMissle", shootInterval, shootInterval);
    }

    public void Update()
    {
        transform.Translate(0.0f, -1 * speed * Time.deltaTime, 0.0f, Space.World);
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerLaser"))
            Destroy(collision.gameObject);
    }

    private void ShootMissle()
    {
        Instantiate(
            missle,
            transform.position,
            Quaternion.identity
        );
    }
}
