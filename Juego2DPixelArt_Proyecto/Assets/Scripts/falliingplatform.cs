using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Collider2D col;

    [SerializeField] private float fallDelay = 0.25f;   // Delay antes de caer
    [SerializeField] private float rotateSpeed = 25f;

    [Header("Respawn en segundos")]
    [SerializeField] private float respawnSeconds = 2f; // Respawn tras X segundos

    private Vector2 initialPosition;
    private Quaternion initialRotation;

    private bool isFalling = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>() ?? GetComponentInParent<Rigidbody2D>();
        col = GetComponent<Collider2D>() ?? GetComponentInParent<Collider2D>();

        initialPosition = transform.position;
        initialRotation = transform.rotation;

        if (rb2D == null) Debug.LogError("FallingPlatform: no se encontr� Rigidbody2D en el objeto o en sus padres.");
        if (col == null) Debug.LogError("FallingPlatform: no se encontr� Collider2D en el objeto o en sus padres.");

        ResetPlatform();
    }

    // Maneja colisiones f�sicas (no trigger). Usa attachedRigidbody para soportar colliders hijos.
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject source = other.collider.attachedRigidbody ? other.collider.attachedRigidbody.gameObject : other.gameObject;
        Debug.Log($"FallingPlatform: colisi�n con '{source.name}' (tag='{source.tag}')");

        if (source.CompareTag("Player") && !isFalling)
        {
            StartCoroutine(StartFall());
        }
    }

    // Maneja el caso en que el collider est� configurado como trigger.
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject source = other.attachedRigidbody ? other.attachedRigidbody.gameObject : other.gameObject;
        Debug.Log($"FallingPlatform (Trigger): entrada de '{source.name}' (tag='{source.tag}')");

        if (source.CompareTag("Player") && !isFalling)
        {
            StartCoroutine(StartFall());
        }
    }

    private IEnumerator StartFall()
    {
        Debug.Log("FallingPlatform: StartFall iniciada, esperando fallDelay...");
        yield return new WaitForSeconds(fallDelay);

        if (rb2D == null)
        {
            Debug.LogError("FallingPlatform: Rigidbody2D es null al iniciar la ca�da.");
            yield break;
        }

        isFalling = true;

        // Aplica f�sica
        rb2D.bodyType = RigidbodyType2D.Dynamic;
        rb2D.constraints = RigidbodyConstraints2D.None;
        rb2D.gravityScale = 1f;
        rb2D.angularVelocity = rotateSpeed;

        Debug.Log($"FallingPlatform: puesto a Dynamic (gravity={rb2D.gravityScale}, bodyType={rb2D.bodyType})");

        // Inicia respawn tras X segundos
        StartCoroutine(RespawnAfterSeconds(respawnSeconds));
    }

    private IEnumerator RespawnAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Respawn();
    }

    void Respawn()
    {
        isFalling = false;
        ResetPlatform();
    }

    void ResetPlatform()
    {
        if (rb2D != null)
        {
            rb2D.linearVelocity = Vector2.zero;
            rb2D.angularVelocity = 0f;
            rb2D.gravityScale = 0f;
            rb2D.bodyType = RigidbodyType2D.Kinematic;
            rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        transform.position = initialPosition;
        transform.rotation = initialRotation;

        if (col != null) col.enabled = true;

        Debug.Log("FallingPlatform: reseteada a posici�n inicial.");
    }
}
