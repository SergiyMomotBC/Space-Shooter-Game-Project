using UnityEngine;
using UnityEngine.UI;

public class PresentLevelTitle : MonoBehaviour
{
    public Text title;

    public void Start()
    {
        title.gameObject.SetActive(true);
        title.text = "Level " + FindObjectOfType<GameplayManager>().level;
        Invoke("HideTitle", 1.5f);
    }

    private void HideTitle()
    {
        Destroy(title.gameObject);
    }
	
}
