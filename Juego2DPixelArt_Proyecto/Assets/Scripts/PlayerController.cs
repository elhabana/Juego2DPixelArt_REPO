using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    //ESTO CREA VARIABLES DENTRO DE UN SCRIPT PARA DESPUES REFERENCIARLAS DENTRO DE UNITY O TAMBIEN PUEDES DEJARLAS PRIVADAS

    public static PlayerController instance;
    public int vida = 3;

    [Header("Player Configuration")]

    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [Header("GroundCheck Configuration")]
    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;
    

    [Header("Respawn Configuration")]
    [SerializeField] Transform respawnPoint;

    //Auto references
    SpriteRenderer sr;
    Rigidbody2D rb;
    Animator anim;
    //General references
    Vector2 moveInput;

    
    // Start is called before the first frame update
    void Start()
    {
        Respawn();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        vida = 3;

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Flip();
        AnimatorHandler();
        if (vida == 0)
        {
            Dead();
        }
    }

    private void FixedUpdate()
    {
        Movement();
        AnimatorHandler();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            AudioManager.instance.PlaySFX(1);
            vida -= 1;
            Respawn();
            collision.gameObject.SetActive(true);
        }
    }


    void Respawn()
    {
        transform.position = respawnPoint.position;
    }

    void Movement()
    {
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);
    }

    void Dead()
    {
            SceneManager.LoadScene(0);
    }

    void Flip()
    {
        if (moveInput.x > 0)
        {
            sr.flipX = false;
        }
        if (moveInput.x < 0)
        {
            sr.flipX = true;
        }
    }

    void AnimatorHandler()
    {
        anim.SetBool("Jump", !isGrounded);
        if (rb.linearVelocity.x > 0.1f || rb.linearVelocity.x < -0.1f)
        {
            anim.SetBool("Run", true);
        }

        else anim.SetBool("Run", false);
    }

    #region Input Methods

    //Escribir M�todos de Input

    #endregion

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            AudioManager.instance.PlaySFX(3);
        }
    }

}
