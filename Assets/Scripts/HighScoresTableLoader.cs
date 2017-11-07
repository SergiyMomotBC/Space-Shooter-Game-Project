using UnityEngine;
using UnityEngine.UI;

public class HighScoresTableLoader : MonoBehaviour
{
    public GameObject[] entries;
	
	public void Awake()
    {
	    for(int i = 0; i < entries.Length; i++)
        {
            var name = PlayerPrefs.GetString("Place" + (i + 1));
            entries[i].transform.FindChild("Name").GetComponent<Text>().text = name;
            entries[i].transform.FindChild("Score").GetComponent<Text>().text = PlayerPrefs.GetInt(name).ToString();
        }
	}
}
