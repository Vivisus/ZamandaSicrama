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
       FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>     // firebasein d�zg�n kurulu olup olmad���n� kontrol ediyoruz
       { if (task.Result == DependencyStatus.Available)
           {
               database = FirebaseFirestore.DefaultInstance;    // firestore k�sm�n� aktif hale getiriyor
               FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync();
           }
           else {
               Debug.LogError("Firebase ile ba�lant� kurulamad�");
               }
       });
        geribildirimButton.onClick.AddListener(FeedbackGonder);
    }


    void FeedbackGonder()
    {
        if (string.IsNullOrEmpty(metinField.text))
        {
            Debug.LogWarning("G�r�� bo� olamaz");
            return;
        }
        var text = metinField.text;
        database.Collection("Feedbacks").AddAsync(text).ContinueWithOnMainThread(task=>
        {
            if (task.IsCompleted) {
            Debug.Log("G�r�� g�nderildi");}
            if (task.IsFaulted)
            {
                Debug.LogError("G�r�� g�nderilemedi" + task.Exception.ToString());
            }
        });
    }
    
}
