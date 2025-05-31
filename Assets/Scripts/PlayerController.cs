using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    Rigidbody2D rb2D;

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public KunaiController kunaiController; // Referencia al script del kunai
    private bool kunaiHabilitado = false;   // Solo se puede lanzar si es true

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.linearVelocity = new Vector2(runSpeed, rb2D.linearVelocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.linearVelocity = new Vector2(-runSpeed, rb2D.linearVelocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            rb2D.linearVelocity = new Vector2(0, rb2D.linearVelocity.y);
            animator.SetBool("Run", false);
        }

        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpSpeed);
        }
        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
        }

        // Habilitar kunai con la tecla P
        if (Input.GetKeyDown(KeyCode.P))
        {
            kunaiHabilitado = true;
        }

        // Solo lanzar kunai si está habilitado
        if (kunaiHabilitado && kunaiController != null && Input.GetKeyDown(KeyCode.L))
        {
            kunaiController.LanzarKunai();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Manzana"))
        {
            Destroy(other.gameObject);
            // Aquí puedes sumar puntaje si lo deseas
        }
    }
}


