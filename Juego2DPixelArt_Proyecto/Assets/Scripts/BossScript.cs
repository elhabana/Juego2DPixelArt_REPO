using Unity.VisualScripting;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    public int life = 20;

    [Header("Detection Range")]
    [SerializeField] float visionRange;
    [SerializeField] Transform player;

    bool playerDetected = false;

    [Header("Energy Ball Shooting")]
    public GameObject energyBall;
    public GameObject energyBall1;
    public GameObject energyBall2;
    public Transform energyBallRespawn;
    public Transform energyBallRespawn1;
    public Transform energyBallRespawn2;

    bool playerInRange;

    bool automaticShooting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        EnergyBallShooting();
        Detection();
        
        if (life == 0)
        {
            SceneManager.LoadScene("EndGame");
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }

    private void Detection()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        playerInRange = distance <= visionRange;

        if (distance <= visionRange && !playerDetected)
        {
            playerDetected = true;
            Debug.Log("Player detected.");
        }

        if (distance > visionRange && playerDetected) 
        {
            playerDetected = false;
            Debug.Log("Player out of range.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Bullet"))
        {
            life = life - 1;
            Debug.Log("Ouch.");
            Debug.Log(life);
        }
    }

    private void Shooting()
    {
        Instantiate(energyBall, energyBallRespawn.position, energyBallRespawn.rotation);
        Instantiate(energyBall1, energyBallRespawn1.position, energyBallRespawn1.rotation);
        Instantiate(energyBall2, energyBallRespawn2.position, energyBallRespawn2.rotation);
        Debug.Log("Energy Balls out.");
    }

    private void EnergyBallShooting()
    {
        if (playerInRange && !automaticShooting)
        {
            InvokeRepeating("Shooting", 1f, 3f);
            automaticShooting = true;
        }

        if (!playerInRange && automaticShooting)
        {
            CancelInvoke("Shooting");
            automaticShooting = false;
        }
    }
}
