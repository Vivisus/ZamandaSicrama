using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Auth;
using System.Collections.Generic;


public class HataBildirme : MonoBehaviour
{
    public InputField hataField;
    public Button hataGonderButton;
    public Button hataKapatButton;
    public Text hataText;
    private FirebaseFirestore database;
    public GameObject HataPanel;

    void Start()
    {
     
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>     // firebasein düzgün kurulu olup olmadigini kontrol ediyoruz
        {
            if (task.Result == DependencyStatus.Available)
            {
                database = FirebaseFirestore.DefaultInstance;    // firestore kismini aktif hale getiriyor
                FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync();
            }
            else
            {
                Debug.LogError("Firebase ile baðlantý kurulamadý");
            }
        });
        hataGonderButton.onClick.AddListener(HataGonder);
        hataKapatButton.onClick.AddListener(HataKapat);

    }

    void HataGonder()
    {
        if (string.IsNullOrEmpty(hataField.text)){
            Debug.LogWarning("Lütfen alaný doldurunuz");
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
                Debug.Log("Hata gönderildi");
            }
            hataField.text = "";
            if (task.IsFaulted)
            {
                Debug.LogError("Hata gönderilemedi" + task.Exception.ToString());
            }
        });
    }
    void HataKapat() { 

        HataPanel.SetActive(false);
    }

}
