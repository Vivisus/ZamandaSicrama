using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;  // TextMeshPro referansı
    public string[] lines;  // Diyalog satırları
    public float textspeed = 0.05f;  // Yazma hızı
    private int index;  // Şu anki diyalog index'i

    void Start()
    {
        textcomponent.text = string.Empty;  // Başlangıçta metni temizle
        StartDialogue();  // Diyaloğu başlat
    }

    void Update()
    {
        // Mouse ile tıklama kontrolü
        if (Input.GetMouseButtonDown(0))  // "input" küçük harf yerine "Input" büyük harf olacak
        {
            if (textcomponent.text == lines[index])  // Eğer diyalog bitmişse
            {
                NextLine();  // Sonraki diyaloğa geç
            }
            else
            {
                StopAllCoroutines();  // Herhangi bir coroutine varsa durdur
                textcomponent.text = lines[index];  // Hızlıca mevcut diyaloğu göster
            }
        }
    }

    // Diyaloğu başlat
    void StartDialogue()
    {
        index = 0;  // Başlangıçta ilk diyaloğu göster
        StartCoroutine(TypeLine());  // İlk diyaloğu yavaşça yazdır
    }

    // Diyaloğu yavaşça yazdır
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())  // Diyalogdaki her harf için
        {
            textcomponent.text += c;  // Harfleri sırayla ekle
            yield return new WaitForSeconds(textspeed);  // Belirtilen hızda bekle
        }
    }

    // Sonraki diyaloğa geçiş
    void NextLine()
    {
        if (index < lines.Length - 1)  // Eğer daha fazla diyalog varsa
        {
            index++;  // Diyalog index'ini arttır
            textcomponent.text = string.Empty;  // Önceki diyaloğu temizle
            StartCoroutine(TypeLine());  // Sonraki diyaloğu yazdır
        }
        else
        {
            gameObject.SetActive(false);  // Tüm diyaloglar bittiğinde paneli gizle
        }
    }
}
