using System.Diagnostics;
using UnityEngine;

public class Saat : MonoBehaviour  // Bu kısımdaki saat objesi karakterin zamanda sıçrama yapacağı nesnedir
{
    public TimeTravel timeTravelScript;
    private bool isInPast = false;  // Şu an geçmişte mi onu kontrol ediyoruz

    private void OnMouseDown() 
    {
         if (timeTravelScript != null)
         {
         timeTravelScript.ZamandaSicra(); // TimeTravel içindeki fonksiyonu çağırıyoruz
         }
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
                if (timeTravelScript != null)
                {
                    timeTravelScript.ZamandaSicra(); // Saat tıklanınca zamanı değiştir
                }
            }
        }
    }

    
