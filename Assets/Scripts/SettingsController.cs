using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider volumeBar;

	public void Awake()
    {
        OnVolumeChanged();
	}

    public void OnVolumeChanged()
    {
        AudioListener.volume = volumeBar.value;
    }
}
