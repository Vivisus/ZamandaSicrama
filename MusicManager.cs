using UnityEngine;
using UnityEngine.UI; // Slider için gerekli

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource; // Ses kaynağı
    public Slider volumeSlider; // UI Slider'ı

    void Start()
    {
        // AudioSource bileşenini al
        audioSource = GetComponent<AudioSource>();

        // Müzik çalmaya başla
        audioSource.Play();

        // Slider başlangıç değerini ses seviyesine göre ayarlayın
        volumeSlider.value = audioSource.volume;

        // Slider değerini değiştirdiğinde SetVolume fonksiyonunu çağır
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Ses seviyesini ayarlamak için fonksiyon
    public void SetVolume(float volume)
    {
        // Ses seviyesini ayarla
        audioSource.volume = volume; // 0.0 - 1.0 arası değerler
    }
}
