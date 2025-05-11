using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTravel : MonoBehaviour
{
    private bool isInPast = false;
    public GameObject[] pastObjects;  // Geçmişte aktif olacak nesneler
    public GameObject[] futureObjects; // Gelecekte aktif olacak nesneler
    public SpriteRenderer background; // Arkaplan resmi
    public Sprite pastBackground; // Geçmiş arkaplanı
    public Sprite futureBackground; // Gelecek arkaplanı
    public Light sceneLight; // Ortam ışığı
    public Color pastLightColor; // Geçmiş için ışık rengi (Örn: Sarımsı)
    public Color futureLightColor; // Gelecek için ışık rengi (Örn: Mavimsi)



    public void ZamandaSicra()
    {
        isInPast = !isInPast;

        foreach (GameObject obj in pastObjects)
        {
            obj.SetActive(isInPast);
        }

        foreach (GameObject obj in futureObjects)
        {
            obj.SetActive(!isInPast);
        }

        background.sprite = isInPast ? pastBackground : futureBackground;
        sceneLight.color = isInPast ? pastLightColor : futureLightColor;

        Debug.Log("Zaman değişti! Şu an: " + (isInPast ? "Geçmiş" : "Gelecek"));
    }
}
