using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Auth;
using System.Collections.Generic;


public class GeriBildirim : MonoBehaviour
{
    public InputField metinField;
    public Button geribildirimButton;
    public Text geribildirimText;
    public Button kapatButton;
    private FirebaseFirestore database;
    public GameObject GeriBildirimPanel;


     
    void Start()
    {
       FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>     // firebasein düzgün kurulu olup olmadigini kontrol ediyoruz
       { if (task.Result == DependencyStatus.Available)
           {
               database = FirebaseFirestore.DefaultInstance;    // firestore kismini aktif hale getiriyor
               FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync();
           }
           else {
               Debug.LogError("Firebase ile bağlantı kurulamadı");
               }
       });
        geribildirimButton.onClick.AddListener(FeedbackGonder);
        kapatButton.onClick.AddListener(kapat);
    }


    void FeedbackGonder()
    {
        if (string.IsNullOrEmpty(metinField.text))
        {
            Debug.LogWarning("Görüş boş olamaz");
            return;
        }
        var feedbackveri = new Dictionary<string, object>
        {
            {"text", metinField.text},
            {"tarih", Timestamp.GetCurrentTimestamp()}
        };
        database.Collection("Feedbacks").AddAsync(feedbackveri).ContinueWithOnMainThread(task=>
        {
            if (task.IsCompleted) {
            Debug.Log("Görüş gönderildi");}
            metinField.text = "";
            if (task.IsFaulted)
            {
                Debug.LogError("Görüş gönderilemedi" + task.Exception.ToString());
            }
        });
    }
    void kapat()
    {
        GeriBildirimPanel.SetActive(false);
    }
    
}
