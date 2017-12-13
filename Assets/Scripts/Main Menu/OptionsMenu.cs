using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class OptionsMenu : MonoBehaviour {

    public AudioMixer audioVolume;
    public Dropdown resDropdown;
    Resolution[] resolutions;


    void Start() {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> resolutionOptions = new List<string>();
        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionOptions.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }
        resDropdown.AddOptions(resolutionOptions);
        resDropdown.value = currentResolutionIndex;
        resDropdown.RefreshShownValue();
    }

    public void VolumeSetting(float volume) {
        audioVolume.SetFloat("MainVolume", volume);        
    }

    public void QualitySetting(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void FullScreenSetting(bool fullscreen) {
        Screen.fullScreen = fullscreen;
    }

    public void ResolutionSettings(int resIndex) {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
