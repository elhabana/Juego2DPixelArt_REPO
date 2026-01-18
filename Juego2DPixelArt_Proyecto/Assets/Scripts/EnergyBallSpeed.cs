using UnityEngine;

public class EnergyBallSpeed : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rbEnergyBall;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbEnergyBall = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbEnergyBall.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            Destroy(gameObject);
            Debug.Log("It hit the Player.");
        }
    }
}
