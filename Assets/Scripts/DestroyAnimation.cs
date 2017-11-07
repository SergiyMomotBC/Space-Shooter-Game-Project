using UnityEngine;

public class DestroyAnimation : MonoBehaviour
{
	public void Start()
    {
        Invoke("Kill", GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length );
	}
	
    private void Kill()
    {
        Destroy(gameObject);
    }
}
