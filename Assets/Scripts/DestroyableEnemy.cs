using UnityEngine;
using System.Collections;

public class DestroyableEnemy : MonoBehaviour
{
    public int points = 100;
    public GameObject explosion;
    public AudioSource deathSound;

    private PlayerController player;
    new private SpriteRenderer renderer;
    new private Collider2D collider;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        collider = GetComponent<Collider2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerLaser"))
        {
            player.OnEnemyKilled(points);
            Destroy(other.gameObject);
            Kill();
        }
    }

    public void Kill()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        deathSound.Play();
        renderer.enabled = false;
        collider.enabled = false;
        Destroy(gameObject, deathSound.clip.length);
        enabled = false;
    }
}
