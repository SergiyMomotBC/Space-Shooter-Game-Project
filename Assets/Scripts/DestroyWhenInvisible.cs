using UnityEngine;

public class DestroyWhenInvisible : MonoBehaviour
{
    new private SpriteRenderer renderer;

    public void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (!renderer.isVisible && transform.position.y < 0.0f)
            Destroy(gameObject);
    }
}
