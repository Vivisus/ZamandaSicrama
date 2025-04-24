using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText; // Diyalog metni
    public Button[] optionButtons; // Seçenek butonları
    public TMP_Text[] buttonTexts; // Buton metni
    public float typingSpeed = 0.1f; // Yazma hızı

    private string[] dialogues; // Diyaloglar
    private int currentDialogueIndex = 0; // Şu anki diyalog index'i
    private string[][] options; // Seçenekler
    private int currentOptionIndex = 0; // Şu anki seçenek index'i

    void Start()
    {
        // Diyalogları TXT dosyasından yükleyelim
        LoadDialogues(); 
        ShowDialogue(); // İlk diyaloğu göster
    }

    // TXT dosyasından diyaloğu yükle
    void LoadDialogues()
    {
        TextAsset dialogueFile = Resources.Load<TextAsset>("dialogues"); // dialogues.txt dosyasını yükle
        dialogues = dialogueFile.text.Split('\n'); // Satırlara göre ayır
        // Burada aynı şekilde seçenekleri de yükleyebiliriz
    }

    // Diyalogları yavaşça yazdır
    IEnumerator TypeDialogue(string dialogue)
    {
        dialogueText.text = "";
        foreach (char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Diyaloğu göster
    void ShowDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            StartCoroutine(TypeDialogue(dialogues[currentDialogueIndex])); // Yavaşça yazdır
            currentDialogueIndex++;
        }
        else
        {
            Debug.Log("Diyalog bitti.");
        }
    }

    // Seçenekleri göstermek
    void ShowOptions(int dialogueIndex)
    {
        for (int i = 0; i < options[dialogueIndex].Length; i++)
        {
            optionButtons[i].gameObject.SetActive(true); // Butonları aktif yap
            buttonTexts[i].text = options[dialogueIndex][i]; // Buton metnini güncelle
            int index = i;
            optionButtons[i].onClick.RemoveAllListeners(); // Önceki eventleri temizle
            optionButtons[i].onClick.AddListener(() => OnOptionSelected(index)); // Seçenek butonuna event ekle
        }
    }

    // Seçeneklere tıklanınca işlem yapmak
    void OnOptionSelected(int index)
    {
        Debug.Log("Seçilen Seçenek: " + options[currentDialogueIndex][index]);
        // Yeni diyaloğa geçiş
        currentDialogueIndex++;
        if (currentDialogueIndex < dialogues.Length)
        {
            ShowDialogue();
        }
        else
        {
            Debug.Log("Diyaloglar bitti.");
        }
    }

    // Next butonuna tıklandığında
    public void OnNextButtonClicked()
    {
        ShowDialogue(); // Bir sonraki diyaloğu göster
    }
}
