using UnityEngine;

public class TankController : MonoBehaviour
{
    public float speed = 4.0f;

    private Transform player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public void Update ()
    {
        if (transform.position.y > player.position.y + 0.5f)
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        else
            transform.Translate(0.0f, -speed * Time.deltaTime, 0.0f);
	}
}
