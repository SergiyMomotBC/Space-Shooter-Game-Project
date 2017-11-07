using UnityEngine;

public class MissleController : MonoBehaviour
{
    public float speed = 3.0f;

    private Transform player;

	public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	public void Update()
    {
        if (transform.position.y > player.position.y + 1.5f)
        {
            var vectorToTarget = player.position - transform.position;
            var angle = (Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg) + 90.0f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.identity;
            transform.Translate(-1 * speed * transform.up * Time.deltaTime);
        }
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PlayerLaser"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
