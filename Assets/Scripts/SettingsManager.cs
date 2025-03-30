using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle soundEffectsToggle;
    public AudioSource backgroundMusic; // Assign in Inspector
    public AudioSource[] soundEffectSources; // Assign in Inspector (all sound effects)

    private const string MusicKey = "MusicEnabled";
    private const string SoundKey = "SoundEnabled";

    void Awake()
    {
        // Ensure the SettingsManager persists across scenes
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Load saved settings
        bool isMusicEnabled = PlayerPrefs.GetInt(MusicKey, 1) == 1;
        bool isSoundEffectsEnabled = PlayerPrefs.GetInt(SoundKey, 1) == 1;

        if (musicToggle != null) musicToggle.isOn = isMusicEnabled;
        if (soundEffectsToggle != null) soundEffectsToggle.isOn = isSoundEffectsEnabled;

        ApplySettings(isMusicEnabled, isSoundEffectsEnabled);

        // Add listeners to detect changes
        if (musicToggle != null) musicToggle.onValueChanged.AddListener(ToggleMusic);
        if (soundEffectsToggle != null) soundEffectsToggle.onValueChanged.AddListener(ToggleSoundEffects);
    }

    void ApplySettings(bool isMusicEnabled, bool isSoundEffectsEnabled)
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.mute = !isMusicEnabled;
        }

        foreach (var sound in soundEffectSources)
        {
            if (sound != null)
            {
                sound.mute = !isSoundEffectsEnabled;
            }
        }
    }

    void ToggleMusic(bool isEnabled)
    {
        PlayerPrefs.SetInt(MusicKey, isEnabled ? 1 : 0);
        PlayerPrefs.Save();
        ApplySettings(isEnabled, PlayerPrefs.GetInt(SoundKey, 1) == 1);
    }

    void ToggleSoundEffects(bool isEnabled)
    {
        PlayerPrefs.SetInt(SoundKey, isEnabled ? 1 : 0);
        PlayerPrefs.Save();
        ApplySettings(PlayerPrefs.GetInt(MusicKey, 1) == 1, isEnabled);
    }
}
