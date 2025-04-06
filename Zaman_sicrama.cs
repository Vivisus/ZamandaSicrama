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
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 tiklanmaKonumu = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(tiklanmaKonumu, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                ToggleTimeTravel();
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    ToggleTimeTravel();
                }
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
    
        background.sprite = isInPast ? pastBackground : futureBackground;
        sceneLight.color = isInPast ? pastLightColor : futureLightColor;
    
        Debug.Log("Zaman değişti! Şu an: " + (isInPast ? "Geçmiş" : "Gelecek"));
    }
}
