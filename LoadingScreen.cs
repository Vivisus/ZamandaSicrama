using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    public GameObject loadingScreen; // Loading Screen Panel
    public Slider LoadingSlider; // Yükleme çubuğu (isteğe bağlı)

    public void PlayGame()
    {
        // Loading ekranını göster
        loadingScreen.SetActive(true);

        // Yükleme işlemi başlat
        StartCoroutine(LoadSceneAsync("Sahne2"));  // Sahne ismi buraya gelecek, örneğin "Sahne2"
    }

    // Sahne yükleme işlemi için IEnumerator fonksiyonu
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // Sahne yüklemeyi başlat
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // Scene yüklendiği sürece yükleme çubuğunu göster
        while (!operation.isDone)
        {
            // Eğer Slider mevcutsa, çubuğun değerini yükleme ilerlemesiyle güncelle
            if (LoadingSlider != null)
            {
                // Yükleme ilerlemesini Slider ile güncelle (0 - 1 arası)
                LoadingSlider.value = operation.progress;
            }

            yield return null;  // Frame bekleyin ve işlemi devam ettirin
        }

        // Yükleme tamamlandığında Loading ekranını gizle
        loadingScreen.SetActive(false);
    }
}
