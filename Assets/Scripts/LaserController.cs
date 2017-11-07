using UnityEngine;

public class LaserController : MonoBehaviour
{
    public float speed = 8.0f;

    private SpriteRenderer spriteRenderer;

	public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	public void Update()
    {
        transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);

        if (!spriteRenderer.isVisible)
           Destroy(gameObject);
	}
}
