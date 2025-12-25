using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] bool isFacingRight;

    [Header("GroundCheck Configuration")]
    [SerializeField] bool isGrounded;
    

    [Header("Respawn Configuration")]
    [SerializeField] Transform respawnPoint;

    //Auto references
    Rigidbody2D rb;
    Animator anim;
    //General references
    Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }


    void Respawn()
    {
        
    }

    void Movement()
    {
        
    }

    void Flip()
    {
        
    }

    void AnimatorHandler()
    {
        
    }

    #region Input Methods

    //Escribir Métodos de Input

    #endregion



}
