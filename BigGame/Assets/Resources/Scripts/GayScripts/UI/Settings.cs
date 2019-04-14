using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Settings : MonoBehaviour {
    public Toggle fullscreenToggle;
    public Dropdown resDropdown, texQualDrop, antiAliasingDrop, vSyncDrop;
    public Slider musicVSlider, sfxVSlider;
    public Button applyButton;

    public AudioSource musicDefualt;
    public Resolution[] resolutions;
    public GameSettings gameSettings;

    void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreenToggle.onValueChanged.AddListener(delegate { OnFullscreenToggle(); });
        resDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        texQualDrop.onValueChanged.AddListener(delegate { OnTexQualityChange(); });
        antiAliasingDrop.onValueChanged.AddListener(delegate { OnAntiAliasingChange(); });
        vSyncDrop.onValueChanged.AddListener(delegate { OnVSyncChange(); });
        musicVSlider.onValueChanged.AddListener(delegate { OnMusicVChange(); });
        sfxVSlider.onValueChanged.AddListener(delegate { OnSFXVChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });


        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }

        LoadSettings();
    }

    public void OnFullscreenToggle()
    {        
        gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resDropdown.value].width, resolutions[resDropdown.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resDropdown.value;
    }

    public void OnTexQualityChange()
    {
        QualitySettings.masterTextureLimit = gameSettings.texQuality = texQualDrop.value;
    }

    public void OnAntiAliasingChange()
    {
        QualitySettings.antiAliasing = (int)Mathf.Pow(2, antiAliasingDrop.value);
        gameSettings.antiAliasing = antiAliasingDrop.value;
    }

    public void OnVSyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSyncDrop.value;
    }

    public void OnSFXVChange()
    {

    }

    public void OnMusicVChange()
    {
        musicDefualt.volume = gameSettings.musicVolume = musicVSlider.value;
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void LoadSettings()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesettings.json") == true)
        {
            gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

            musicVSlider.value = gameSettings.musicVolume;
            antiAliasingDrop.value = gameSettings.antiAliasing;
            vSyncDrop.value = gameSettings.vSync;
            texQualDrop.value = gameSettings.texQuality;
            resDropdown.value = gameSettings.resolutionIndex;
            fullscreenToggle.isOn = gameSettings.fullscreen;
            Screen.fullScreen = gameSettings.fullscreen;

            resDropdown.RefreshShownValue();
        }
    }
}
