using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        // Łączymy się z fizyką obiektu
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Czytamy klawisze (W, S, A, D lub strzałki)
        // GetAxisRaw sprawia, że ruch jest natychmiastowy (bez ślizgania)
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Nadajemy prędkość bezpośrednio. 
        // Jeśli moveInput jest 0 (nic nie klikasz), prędkość też będzie 0.
        rb.velocity = moveInput.normalized * speed;
    }
}