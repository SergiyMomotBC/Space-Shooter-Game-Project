using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float speed = 3.0f;
    public Sprite[] asteroidSkins;

    new private SpriteRenderer renderer;

	public void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = asteroidSkins[Random.Range(0, asteroidSkins.Length - 1)];

        var collider = gameObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
	}
	
	public void Update()
    {
        transform.Translate(0.0f, -1 * speed * Time.deltaTime, 0.0f, Space.World);
        transform.Rotate(Vector3.forward * 30 * speed * Time.deltaTime);
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerLaser"))
            Destroy(other.gameObject);
    }
}
