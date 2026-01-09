using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb2D;
    
    private bool fall = false;
    [SerializeField] private float fallDelay = 1f;
    [SerializeField] private float rotateSpeed = 100f;

    [Header("Respawn por Frames")]
    [SerializeField] private int respawnFrames = 120; // X frames




     void Start()
    {
       rb2D = GetComponent<Rigidbody2D>();
        


    }

   private void OnCollisionEnter2D(Collision2D other)
    {
      if(other.gameObject.CompareTag("Player"))
        {
            fall = true;
            StartCoroutine(caida(other));
        }

    }

    private IEnumerator caida(Collision2D other)
    {
        yield return new WaitForSeconds(fallDelay);
        fall = true;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), other.transform.GetComponent<Collider2D>());
        rb2D.constraints = RigidbodyConstraints2D.None;
        rb2D.AddForce(new Vector2(0.1f, 0));



    }
   

    private IEnumerator Caida(Collision2D other)
    {
        yield return new WaitForSeconds(fallDelay);

        rb2D.constraints = RigidbodyConstraints2D.None;
    }




    // Update is called once per frame
    void Update()
    {

        rb2D.bodyType = RigidbodyType2D.Dynamic;
        rb2D.angularVelocity = rotateSpeed;




    }
}
