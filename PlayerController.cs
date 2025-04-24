using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;       // Karakterin hareket hızı
    private Rigidbody2D rb;            // Rigidbody2D bileşeni
    public bl_Joystick joystick;       // bl_Joystick bileşeni
    private Animator animator;         // Animator bileşeni
    public Collider2D playerCollider;  // Karakterin Collider bileşeni

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // Rigidbody2D bileşenini al
        animator = GetComponent<Animator>(); // Animator bileşenini al
        playerCollider = GetComponent<Collider2D>(); // Collider bileşenini al
    }
     void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag("Floor")) {
        // Floor üzerine geldiğinde hareketi devam etmesine izin ver
    }
    else {
        // Floor dışında bir yere gittiğinde hareketi durdur
        rb.linearVelocity = Vector2.zero; // Durmak için hızı sıfırlayın
    }
}
          

    void Update()
    {
        // Joystick giriş verilerini al
        float moveX = joystick.Horizontal;  // Joystick'in yatay hareketi
        float moveY = joystick.Vertical;    // Joystick'in dikey hareketi

        // Hareket yönünü belirle
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        // Eğer joystick hareket ediyorsa, isRunning parametresini true yap
        if (moveDirection.magnitude > 0.1f)
        {
            animator.SetBool("isRunning", true);  // Yürüyüş animasyonunu başlat

            // Yönü belirle
            Vector2 velocity = moveDirection * moveSpeed;
            rb.linearVelocity = velocity; // Rigidbody2D'yi kullanarak hareket ettir

            // Karakterin hareket yönüne göre dönmesini sağla
            if (moveX != 0 || moveY != 0)
            {
                float angle = Mathf.Atan2(moveY, moveX) * Mathf.Rad2Deg; // Yön açısını hesapla
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Karakteri döndür
            }
        }
        else
        {
            animator.SetBool("isRunning", false);  // Durduğunda idle animasyonuna geç
            rb.linearVelocity = Vector2.zero;  // Hareket etmiyor
        }
    }
}
