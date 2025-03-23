using UnityEngine;
using UnityEngine.UI;

public class ScreenResolutionChanger : MonoBehaviour
{
    public Dropdown resolutionDropdown; // Dropdown menüsünü Unity Inspector'dan atayın

    void Start()
    {
        // Dropdown menüsüne seçenekleri ekleyin
        PopulateDropdown();

        // İlk başta seçili olan ekran boyutunu uygula
        SetResolution(resolutionDropdown.value);
        
        // Dropdown menüsüne listener ekleyerek her seçimde ekran boyutunu değiştir
        resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution(resolutionDropdown.value); });
    }

    void PopulateDropdown()
    {
        // Dropdown menüsüne ekran boyutlarını ekleyin
        resolutionDropdown.ClearOptions();

        var resolutions = new string[] { "1920x1080", "1280x720", "1024x768", "800x600" }; // Ekran boyutlarını buraya ekleyebilirsiniz

        resolutionDropdown.AddOptions(new System.Collections.Generic.List<string>(resolutions));
    }

    void SetResolution(int index)
    {
        // Seçilen değere göre ekran boyutunu değiştir
        switch (index)
        {
            case 0: // 1920x1080
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1: // 1280x720
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
            case 2: // 1024x768
                Screen.SetResolution(1024, 768, Screen.fullScreen);
                break;
            case 3: // 800x600
                Screen.SetResolution(800, 600, Screen.fullScreen);
                break;
            default:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
        }
    }
}
