using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource soundSource;
    private AudioSource musicSource;

    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();

        if (soundSource == null || musicSource == null)
        {
            Debug.LogError("AudioSource component missing. Attach AudioSource components to the SoundManager GameObject and its first child.");
            return;
        }

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        ChangeMusicVolume(0);
        ChangeSoundVolume(0);
    }

    public void PlaySound(AudioClip _sound)
    {
        if (soundSource != null)
            soundSource.PlayOneShot(_sound);
        else
            Debug.LogError("No soundSource found to play the sound.");
    }

    public void ChangeSoundVolume(float _change)
    {
        if (soundSource != null)
            ChangeSourceVolume(1, "soundVolume", _change, soundSource);
        else
            Debug.LogError("No soundSource found to change the volume.");
    }

    public void ChangeMusicVolume(float _change)
    {
        if (musicSource != null)
            ChangeSourceVolume(0.3f, "musicVolume", _change, musicSource);
        else
            Debug.LogError("No musicSource found to change the volume.");
    }

    private void ChangeSourceVolume(float baseVolume, string volumeName, float change, AudioSource source)
    {
        if (source == null)
        {
            Debug.LogError("No AudioSource component found.");
            return;
        }

        float currentVolume = PlayerPrefs.GetFloat(volumeName, 1);
        currentVolume += change;

        if (currentVolume > 1)
            currentVolume = 0;
        else if (currentVolume < 0)
            currentVolume = 1;

        float finalVolume = currentVolume * baseVolume;
        source.volume = finalVolume;

        PlayerPrefs.SetFloat(volumeName, currentVolume);
    }
}
