using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject canvas1; // İlk açılacak Canvas
    public GameObject canvas2; // Geçiş yapılacak Canvas
    public Button switchButton; // Buton

    void Start()
    {
        // Başlangıçta Canvas1 aktif, Canvas2 pasif olacak
        canvas1.SetActive(true);
        canvas2.SetActive(false);

        // Butona tıklama olayını bağla
        if (switchButton != null)
        {
            switchButton.onClick.AddListener(SwitchCanvas);
        }
    }

    void SwitchCanvas()
    {
        // Canvas1'i kapat, Canvas2'yi aç
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }
}
