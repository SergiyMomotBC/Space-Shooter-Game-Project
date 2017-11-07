using UnityEngine;

public class PersistantData : MonoBehaviour
{
    public int health = 3;
    public int score = 0;
	
	public void Awake()
    {
        if (FindObjectsOfType<PersistantData>().Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
	}
}
