using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rbBullet;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbBullet = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 7f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbBullet.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Boss"))
        {
            Destroy(gameObject);
            Debug.Log("It hit the boss");
        }
    }
}
