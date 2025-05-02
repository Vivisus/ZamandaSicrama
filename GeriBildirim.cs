using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Firestore;
using Firebase.Extensions;
using Firebase.Auth;


public class GeriBildirim : MonoBehaviour
{
    public InputField metinField;
    public Button geribildirimButton;
    public Text geribildirimText;
    public Button kapatButton;
    private FirebaseFirestore database;



     
    void Start()
    {
       FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>     // firebasein düzgün kurulu olup olmadýðýný kontrol ediyoruz
       { if (task.Result == DependencyStatus.Available)
           {
               database = FirebaseFirestore.DefaultInstance;    // firestore kýsmýný aktif hale getiriyor
               FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync();
           }
           else {
               Debug.LogError("Firebase ile baðlantý kurulamadý");
               }
       });
        geribildirimButton.onClick.AddListener(FeedbackGonder);
    }


    void FeedbackGonder()
    {
        if (string.IsNullOrEmpty(metinField.text))
        {
            Debug.LogWarning("Görüþ boþ olamaz");
            return;
        }
        var text = metinField.text;
        database.Collection("Feedbacks").AddAsync(text).ContinueWithOnMainThread(task=>
        {
            if (task.IsCompleted) {
            Debug.Log("Görüþ gönderildi");}
            if (task.IsFaulted)
            {
                Debug.LogError("Görüþ gönderilemedi" + task.Exception.ToString());
            }
        });
    }
    
}
