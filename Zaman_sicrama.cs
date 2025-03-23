using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeTravel : MonoBehaviour
{
    private bool isInPast = false;

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

    void ToggleTimeTravel()
    {
        if (isInPast)
        {
            SceneManager.LoadScene("FutureScene"); 
            Debug.Log("Geleceğe döndü!");
        }
        else
        {
            SceneManager.LoadScene("PastScene"); 
            Debug.Log("Geçmişe gitti!");
        }
        isInPast = !isInPast;
    }
}
