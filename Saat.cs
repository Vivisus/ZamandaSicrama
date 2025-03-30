using System.Diagnostics;
using UnityEngine;

public class Saat : MonoBehaviour  // Bu kısımdaki saat objesi karakterin zamanda sıçrama yapacağı nesnedir
{
    public GameObject pastObjects;  
    public GameObject futureObjects; 

    private bool isInPast = false;  // Şu an geçmişte mi onu kontrol ediyoruz

    private void OnMouseDown() 
    {
        ZamandaSicra();
    }

    private void Update()
    {
        if (Input.touchCount > 0) 
        {
            Touch dokunma = Input.GetTouch(0);
            Vector2 dokunmaKonumu = Camera.main.ScreenToWorldPoint(dokunma.position);
            Collider2D tıklananObje = Physics2D.OverlapPoint(dokunmaKonumu);

            if (tıklananObje != null && tıklananObje.gameObject == gameObject)
            {
                ZamandaSicra();
            }
        }
    }

    void ZamandaSicra()
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

        Debug.Log("Zaman değişti! Yeni zaman: " + (isInPast ? "Geçmiş" : "Gelecek"));
    }
}
