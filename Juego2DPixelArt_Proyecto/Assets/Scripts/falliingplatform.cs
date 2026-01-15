using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Collider2D col;

    [SerializeField] private float fallDelay = 0.25f;   // Delay antes de caer
    [SerializeField] private float rotateSpeed = 25f;

    [Header("Respawn por Frames")]
    [SerializeField] private int respawnFrames = 10;    // Respawn tras 10 frames

    private Vector2 initialPosition;
    private Quaternion initialRotation;

    private bool isFalling = false;
    private int frameCounter = 0;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        initialPosition = transform.position;
        initialRotation = transform.rotation;

        ResetPlatform();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isFalling)
        {
            StartCoroutine(StartFall());
        }
    }

    private IEnumerator StartFall()
    {
        yield return new WaitForSeconds(fallDelay);

        isFalling = true;
        frameCounter = 0;

        rb2D.bodyType = RigidbodyType2D.Dynamic;
        rb2D.constraints = RigidbodyConstraints2D.None;
        rb2D.gravityScale = 1f;
        rb2D.angularVelocity = rotateSpeed;
    }

    void Update()
    {
        if (!isFalling) return;

        frameCounter++;

        if (frameCounter >= respawnFrames)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        isFalling = false;
        ResetPlatform();
    }

    void ResetPlatform()
    {
        rb2D.linearVelocity = Vector2.zero;
        rb2D.angularVelocity = 0f;
        rb2D.gravityScale = 0f;
        rb2D.bodyType = RigidbodyType2D.Kinematic;
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        transform.position = initialPosition;
        transform.rotation = initialRotation;

        col.enabled = true;
    }
}
