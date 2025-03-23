using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer audioMixer; // Ses kontrolü için AudioMixer
    public Slider volumeSlider;   // UI Slider

    void Start()
    {
        // Oyunun başında slider'ı kaydedilmiş değere ayarla
        if (PlayerPrefs.HasKey("GameVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("GameVolume");
            volumeSlider.value = savedVolume;
            SetVolume(savedVolume);
        }
    }

    public void SetVolume(float volume)
    {
        // AudioMixer kullanarak sesi değiştiriyoruz (-80 ile 0 dB arasında çalışır)
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);

        // Ses seviyesini kaydet
        PlayerPrefs.SetFloat("GameVolume", volume);
    }
}
