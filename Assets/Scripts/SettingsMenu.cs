using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public Toggle fullscreenToggle;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown antialiasingDropdown;
    public Toggle vsyncToggle;
    public Slider globalVolumeSlider;
    public Button applyButton;

    public AudioSource audioSource;
    public Resolution[] resolutions;
    public GameSettings gameSettings;

    private void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        antialiasingDropdown.onValueChanged.AddListener(delegate { OnAntialiasingChange(); });
        vsyncToggle.onValueChanged.AddListener(delegate { OnVsyncToggle(); });
        globalVolumeSlider.onValueChanged.AddListener(delegate { OnVolumeChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButton(); });

        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolution.ToString()));
        }
        LoadSettings();
    }

    public void OnApplyButton()
    {
        SaveSettings();
    }
    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings,true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }
    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
        globalVolumeSlider.value = gameSettings.globalVolume;
        antialiasingDropdown.value = gameSettings.antialiasing;
        if (gameSettings.vSync == 0)
        {
            vsyncToggle.isOn = false;
        } else
        {
            vsyncToggle.isOn = true;
        }
        resolutionDropdown.value = gameSettings.resolutionIndex;
        fullscreenToggle.isOn = gameSettings.fullscreen;

        resolutionDropdown.RefreshShownValue();
    }
    public void OnFullscreenToggle()
    {
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }
    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionDropdown.value;
    }
    public void OnAntialiasingChange()
    {
        QualitySettings.antiAliasing = (int)Mathf.Pow(2, antialiasingDropdown.value);
    }
    public void OnVsyncToggle()
    {
        if (!vsyncToggle.isOn)
        {
            gameSettings.vSync = QualitySettings.vSyncCount = 0;
        } else if (vsyncToggle.isOn)
        {
            gameSettings.vSync = QualitySettings.vSyncCount = 1;
        }
    }
    public void OnVolumeChange()
    {
        globalVolumeSlider.value = audioSource.volume = gameSettings.globalVolume;
    }
}
