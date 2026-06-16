using UnityEngine;

public class JugadorController : MonoBehaviour
{
    [Header("MOVIMIENTO")]
    public float velocidad = 7f;
    public float fuerzaSalto = 15f;
    private Rigidbody2D rb;
    private float inputHorizontal;
    private bool puedeSaltar = true;
    
    [Header("INTERACCIÓN")]
    public GameObject puertaCerca;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        // Movimiento horizontal
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        
        // Salto (Espacio)
        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            puedeSaltar = false;
        }
        
        // Interacción con puerta (E o flecha arriba)
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (puertaCerca != null)
            {
                Puerta puerta = puertaCerca.GetComponent<Puerta>();
              if (puerta != null) puerta.Interactuar();
            }
        }
    }
    
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(inputHorizontal * velocidad, rb.linearVelocity.y);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar suelo para permitir salto
        if (collision.gameObject.CompareTag("Suelo"))
            puedeSaltar = true;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puerta"))
            puertaCerca = other.gameObject;
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Puerta"))
            puertaCerca = null;
    }
}