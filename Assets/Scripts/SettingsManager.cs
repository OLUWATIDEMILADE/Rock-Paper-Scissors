using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance; // Singleton instance

    public Toggle musicToggle; // Toggle for background music
    public Toggle soundEffectsToggle; // Toggle for sound effects

    public AudioSource backgroundMusicSource; // Reference to background music AudioSource
    public AudioSource soundEffectsSource;    // Reference to sound effects AudioSource

    private const string MusicKey = "MusicEnabled";
    private const string SoundKey = "SoundEnabled";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Assign the singleton instance
            DontDestroyOnLoad(gameObject); // Prevent destruction when switching scenes
        }
        else
        {
            Destroy(gameObject); // Avoid duplicate instances
        }
    }

    private void Start()
    {
        // Load saved preferences
        if (musicToggle != null)
        {
            musicToggle.isOn = PlayerPrefs.GetInt(MusicKey, 1) == 1;
            musicToggle.onValueChanged.AddListener(ToggleMusic);
        }

        if (soundEffectsToggle != null)
        {
            soundEffectsToggle.isOn = PlayerPrefs.GetInt(SoundKey, 1) == 1;
            soundEffectsToggle.onValueChanged.AddListener(ToggleSoundEffects);
        }

        // Apply the settings immediately
        ToggleMusic(musicToggle?.isOn ?? true);
        ToggleSoundEffects(soundEffectsToggle?.isOn ?? true);
    }

    public void ToggleMusic(bool isEnabled)
    {
        PlayerPrefs.SetInt(MusicKey, isEnabled ? 1 : 0);
        PlayerPrefs.Save();

        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.mute = !isEnabled; // Mute or unmute the background music
        }
    }

    public void ToggleSoundEffects(bool isEnabled)
    {
        PlayerPrefs.SetInt(SoundKey, isEnabled ? 1 : 0);
        PlayerPrefs.Save();

        if (soundEffectsSource != null)
        {
            soundEffectsSource.mute = !isEnabled; // Mute or unmute the sound effects
        }
    }

   
}
