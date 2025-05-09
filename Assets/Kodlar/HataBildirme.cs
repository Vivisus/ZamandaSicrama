using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Auth;
using System.Collections.Generic;
// firebase storage k�sm�n� import et!!!!!

public class HataBildirme : MonoBehaviour
{
    public InputField hataField;
    public Button hataGonderButton;
    public Button hataKapatButton;
    public Text hataText;
    public Button ekranButton;
    private FirebaseFirestore database;
    public GameObject HataPanel;

    void Start()
    {
     
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>     // firebasein d�zg�n kurulu olup olmadigini kontrol ediyoruz
        {
            if (task.Result == DependencyStatus.Available)
            {
                database = FirebaseFirestore.DefaultInstance;    // firestore kismini aktif hale getiriyor
                FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync();
            }
            else
            {
                Debug.LogError("Firebase ile ba�lant� kurulamad�");
            }
        });
        hataGonderButton.onClick.AddListener(HataGonder);
        hataKapatButton.onClick.AddListener(HataKapat);
        ekranButton.onClick.AddListener(EkranGoruntusu);

    }

    void HataGonder()
    {
        if (string.IsNullOrEmpty(hataField.text)){
            Debug.LogWarning("L�tfen alan� doldurunuz");
            return;
        }
        var hataveri = new Dictionary<string, object>
        {
            {"metin", hataField.text},
            {"Tarih", Timestamp.GetCurrentTimestamp()}
        };
        database.Collection("Hatalar").AddAsync(hataveri).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Hata g�nderildi");
            }
            hataField.text = "";
            if (task.IsFaulted)
            {
                Debug.LogError("Hata g�nderilemedi" + task.Exception.ToString());
            }
        });




    }
    void HataKapat() { 

        HataPanel.SetActive(false);
    }
    void EkranGoruntusu()
    {
        // ekran g�r�nt�s� alma fonksiyonunu yaz
    }
}
